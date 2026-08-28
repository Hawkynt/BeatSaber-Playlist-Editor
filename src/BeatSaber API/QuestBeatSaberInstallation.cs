using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;

namespace BeatSaberAPI;

/// <summary>
/// Mirrors a modded Meta Quest Beat Saber installation over ADB and keeps playlist writes synchronized.
/// </summary>
public sealed class QuestBeatSaberInstallation : IBeatSaberInstallation, IDisposable {
  private const string SONG_CORE_LEVELS = "/sdcard/ModData/com.beatgames.beatsaber/Mods/SongCore/CustomLevels";
  private const string LEGACY_SONG_LOADER_LEVELS = "/sdcard/ModData/com.beatgames.beatsaber/Mods/SongLoader/CustomLevels";
  private const string PLAYLISTS = "/sdcard/ModData/com.beatgames.beatsaber/Mods/PlaylistManager/Playlists";

  private readonly string _adbPath;
  private readonly string? _serial;
  private readonly DirectoryInfo _mirrorRoot;
  private readonly DirectoryInfo _playlistDirectory;
  private readonly BeatSaberInstallation _mirror;
  private bool _disposed;

  public IPlaylistCollection Playlists { get; }
  public ISongCollection Songs => this._mirror.Songs;

  public QuestBeatSaberInstallation(string? adbPath = null, string? serial = null) {
    this._adbPath = _ResolveAdb(adbPath);
    this._serial = serial.IsNullOrWhiteSpace() ? null : serial;
    this._EnsureDeviceAvailable();

    this._mirrorRoot = new DirectoryInfo(Path.Combine(Path.GetTempPath(), "BeatSaber-Playlist-Editor", "Quest", Guid.NewGuid().ToString("N")));
    var songDirectory = this._mirrorRoot.Directory("Beat Saber_Data").Directory("CustomLevels");
    this._playlistDirectory = this._mirrorRoot.Directory("Playlists");
    songDirectory.Create();
    this._playlistDirectory.Create();

    this._PullDirectoryIfPresent(SONG_CORE_LEVELS, songDirectory);
    this._PullDirectoryIfPresent(LEGACY_SONG_LOADER_LEVELS, songDirectory);
    this._PullDirectoryIfPresent(PLAYLISTS, this._playlistDirectory);

    this._mirror = BeatSaberInstallation.FromGameDirectory(this._mirrorRoot);
    this.Playlists = new SyncedPlaylistCollection(this, this._mirror.Playlists);
  }

  private static string _ResolveAdb(string? adbPath) {
    if (adbPath.IsNotNullOrWhiteSpace())
      return adbPath!;

    var candidates = new[] {
      Environment.GetEnvironmentVariable("ADB_PATH"),
      Environment.GetEnvironmentVariable("ANDROID_HOME") is { Length: > 0 } androidHome ? Path.Combine(androidHome, "platform-tools", "adb.exe") : null,
      Environment.GetEnvironmentVariable("ANDROID_SDK_ROOT") is { Length: > 0 } androidSdkRoot ? Path.Combine(androidSdkRoot, "platform-tools", "adb.exe") : null,
      Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) is { Length: > 0 } localAppData ? Path.Combine(localAppData, "Android", "Sdk", "platform-tools", "adb.exe") : null
    };

    return candidates.FirstOrDefault(File.Exists) ?? "adb";
  }

  private void _EnsureDeviceAvailable() {
    var result = this._RunAdb(false, "get-state");
    if (result.ExitCode == 0 && result.StandardOutput.Contains("device", StringComparison.OrdinalIgnoreCase))
      return;

    var detail = (result.StandardError + Environment.NewLine + result.StandardOutput).Trim();
    throw new InvalidOperationException(
      "Could not connect to a Meta Quest through ADB. Enable Developer Mode/USB debugging, authorize this PC in the headset, and make sure adb.exe is installed or configured via ADB_PATH."
      + (detail.Length == 0 ? string.Empty : $"{Environment.NewLine}{detail}")
    );
  }

  private void _PullDirectoryIfPresent(string remoteDirectory, DirectoryInfo localDirectory) {
    if (this._RunAdb(false, "shell", "test", "-d", remoteDirectory).ExitCode != 0)
      return;

    localDirectory.Create();
    this._RunAdb(true, "pull", $"{remoteDirectory}/.", localDirectory.FullName);
  }

  private void _SyncPlaylistsToDevice() {
    this._ThrowIfDisposed();

    // The mirror was initially pulled wholesale, so replacing the directory preserves subfolders,
    // cover images and playlist formats that this editor does not actively modify.
    this._RunAdb(true, "shell", "rm", "-rf", PLAYLISTS);
    this._RunAdb(true, "shell", "mkdir", "-p", PLAYLISTS);
    this._RunAdb(true, "push", $"{this._playlistDirectory.FullName}{Path.DirectorySeparatorChar}.", PLAYLISTS);
  }

  private AdbResult _RunAdb(bool requireSuccess, params string[] arguments) {
    var startInfo = new ProcessStartInfo {
      FileName = this._adbPath,
      UseShellExecute = false,
      RedirectStandardOutput = true,
      RedirectStandardError = true,
      CreateNoWindow = true
    };

    if (this._serial.IsNotNullOrWhiteSpace()) {
      startInfo.ArgumentList.Add("-s");
      startInfo.ArgumentList.Add(this._serial!);
    }

    foreach (var argument in arguments)
      startInfo.ArgumentList.Add(argument);

    try {
      using var process = Process.Start(startInfo) ?? throw new InvalidOperationException("Could not start adb.exe.");
      var standardOutput = process.StandardOutput.ReadToEndAsync();
      var standardError = process.StandardError.ReadToEndAsync();
      process.WaitForExit();

      var result = new AdbResult(process.ExitCode, standardOutput.GetAwaiter().GetResult(), standardError.GetAwaiter().GetResult());
      if (requireSuccess && result.ExitCode != 0)
        throw new InvalidOperationException($"ADB failed ({result.ExitCode}): {result.StandardError.Trim()}");

      return result;
    } catch (System.ComponentModel.Win32Exception exception) {
      throw new InvalidOperationException(
        "adb.exe was not found. Install Android Platform Tools or set the ADB_PATH environment variable to adb.exe.",
        exception
      );
    }
  }

  private void _ThrowIfDisposed() => ObjectDisposedException.ThrowIf(this._disposed, this);

  public void Dispose() {
    if (this._disposed)
      return;

    this._disposed = true;
    try {
      if (this._mirrorRoot.Exists)
        this._mirrorRoot.Delete(true);
    } catch (IOException) {
      // A preview image can briefly hold a file while WinForms tears down. Temp cleanup is best-effort.
    } catch (UnauthorizedAccessException) {
      // Same as above; the OS temp directory can clean this up later.
    }
  }

  private readonly record struct AdbResult(int ExitCode, string StandardOutput, string StandardError);

  private sealed class SyncedPlaylistCollection(QuestBeatSaberInstallation owner, IPlaylistCollection inner) : IPlaylistCollection {
    public IPlaylist Create(string name) => new SyncedPlaylist(owner, inner.Create(name));

    public void Delete(string name) {
      inner.Delete(name);
      owner._SyncPlaylistsToDevice();
    }

    public IEnumerator<IPlaylist> GetEnumerator()
      => inner.Select(playlist => (IPlaylist)new SyncedPlaylist(owner, playlist)).GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
  }

  private sealed class SyncedPlaylist(QuestBeatSaberInstallation owner, IPlaylist inner) : IPlaylist {
    public string Name {
      get => inner.Name;
      set => inner.Name = value;
    }

    public string? Author {
      get => inner.Author;
      set => inner.Author = value;
    }

    public string? Description {
      get => inner.Description;
      set => inner.Description = value;
    }

    public Image? Image => inner.Image;
    public IPlaylistEntryCollection Songs => inner.Songs;

    public IPlaylistEntry CreateEntry(ISong song, string? displayName = null) => inner.CreateEntry(song, displayName);

    public void WriteToDisk() {
      inner.WriteToDisk();
      owner._SyncPlaylistsToDevice();
    }

    public void SetImage(Image? image) => inner.SetImage(image);
  }
}
