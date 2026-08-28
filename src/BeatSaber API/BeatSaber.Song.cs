using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text.Json;
using BeatSaberAPI.JSON;

namespace BeatSaberAPI;

partial class BeatSaberInstallation {

  [DebuggerDisplay($"{{{nameof(Artist)}}} - {{{nameof(Title)}}}")]
  private class Song : ISong {

    private const int HASH_BUFFER_SIZE = 81920;
    private readonly Lazy<SongInfo.Root> _data;

    public DirectoryInfo Directory { get; }
    private SongInfo.Root _Data => this._data.Value;
    public string Title => this._Data.SongName!;
    public string? Artist => this._Data.SongAuthorName.DefaultIfNullOrWhiteSpace();
    private IEnumerable<SongInfo.DifficultyBeatmapSet> _DifficultyBeatmapSets => this._Data.DifficultyBeatmapSets as IEnumerable<SongInfo.DifficultyBeatmapSet> ?? [];
    public bool SupportsStandardMode => this._DifficultyBeatmapSets.Any(i => i.BeatmapCharacteristicName!.Equals("Standard", StringComparison.OrdinalIgnoreCase));
    public bool SupportsOneSaberMode => this._DifficultyBeatmapSets.Any(i => i.BeatmapCharacteristicName!.Equals("OneSaber", StringComparison.OrdinalIgnoreCase));
    public bool SupportsNoArrowsMode => this._DifficultyBeatmapSets.Any(i => i.BeatmapCharacteristicName!.Equals("NoArrows", StringComparison.OrdinalIgnoreCase));
    public bool Supports90DegreesMode => this._DifficultyBeatmapSets.Any(i => i.BeatmapCharacteristicName!.Equals("90Degree", StringComparison.OrdinalIgnoreCase));
    public bool Supports360DegreesMode => this._DifficultyBeatmapSets.Any(i => i.BeatmapCharacteristicName!.Equals("360Degree", StringComparison.OrdinalIgnoreCase));
    public GameMode SupportedGameModes =>
      (this.SupportsStandardMode ? GameMode.Normal : 0)
      | (this.SupportsOneSaberMode ? GameMode.OneSaber : 0)
      | (this.SupportsNoArrowsMode ? GameMode.NoArrows : 0)
      | (this.Supports90DegreesMode ? GameMode.NinetyDegrees : 0)
      | (this.Supports360DegreesMode ? GameMode.ThreeSixtyDegrees : 0);

    public IReadOnlyDictionary<GameMode, DifficultyMode> Difficulties {
      get {
        Dictionary<GameMode, DifficultyMode> result = [];
        foreach (var mode in this._DifficultyBeatmapSets) {
          var gameMode = mode.BeatmapCharacteristicName!.ToLowerInvariant() switch {
            "standard" => GameMode.Normal,
            "onesaber" => GameMode.OneSaber,
            "noarrows" => GameMode.NoArrows,
            "90degree" => GameMode.NinetyDegrees,
            "360degree" => GameMode.ThreeSixtyDegrees,
            _ => (GameMode)(-1)
          };
          if ((int)gameMode == -1)
            continue;

          DifficultyMode value = 0;
          foreach (var difficulty in mode.DifficultyBeatmaps ?? [])
            value |= (difficulty.Difficulty ?? string.Empty).ToLowerInvariant() switch {
              "easy" => DifficultyMode.Easy,
              "normal" => DifficultyMode.Normal,
              "hard" => DifficultyMode.Hard,
              "expert" => DifficultyMode.Expert,
              "expertplus" => DifficultyMode.ExpertPlus,
              _ => 0
            };

          result[gameMode] = value;
        }

        return result;
      }
    }

    public Image? Image => this.GetCover();
    public string? LevelAuthor => this._Data.LevelAuthorName;
    public double BeatsPerMinute => this._Data.BeatsPerMinute;
    public string? Environment => this._Data.EnvironmentName;

    public Song(DirectoryInfo directory) {
      this.Directory = directory;
      this._data = new(this._ReadMetadata);
    }

    public FileInfo? GetCoverFile() {
      var coverFileName = this._Data.CoverImageFilename;
      if (coverFileName.IsNullOrWhiteSpace())
        return null;

      return this.Directory.File(coverFileName);
    }

    public FileInfo? GetSongFile() => this._Data.SongFilename?.Trim() is { Length: > 0 } songFileName
      ? this.Directory.File(songFileName)
      : null;

    public string CalculateChecksum() {
      using var crypto = SHA1.Create();
      var buffer = new byte[HASH_BUFFER_SIZE];
      _AppendFileToHash(crypto, _GetInfoFile(this.Directory), buffer);
      foreach (var set in this._DifficultyBeatmapSets)
        foreach (var map in set.DifficultyBeatmaps ?? [])
          if (map.BeatmapFilename is { Length: > 0 } fileName)
            _AppendFileToHash(crypto, this.Directory.File(fileName), buffer);

      crypto.TransformFinalBlock([], 0, 0);
      return crypto.Hash!.ToHex(true);
    }

    private static void _AppendFileToHash(HashAlgorithm hash, FileInfo file, byte[] buffer) {
      using var stream = file.OpenRead();
      int read;
      while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
        hash.TransformBlock(buffer, 0, read, null, 0);
    }

    public Image? GetCover() => this._ReadCover();

    private static FileInfo _GetInfoFile(DirectoryInfo source) => source.File("Info.dat");

    private SongInfo.Root _ReadMetadata() {
      using var fileStream = _GetInfoFile(this.Directory).OpenRead();
      return JsonSerializer.Deserialize<SongInfo.Root>(fileStream) ?? throw new InvalidDataException($"Invalid song metadata in '{this.Directory.FullName}'.");
    }

    private Image? _ReadCover() {
      var coverFile = this.GetCoverFile();
      if (coverFile?.NotExists() ?? true)
        return null;

      try {
        using var stream = coverFile!.OpenRead();
        using var source = Image.FromStream(stream);
        return new Bitmap(source);
      } catch (Exception e) {
        Trace.WriteLine($"{nameof(this._ReadCover)}: Error loading cover '{coverFile!.FullName}': {e}");
        return null;
      }
    }

    public static bool TryCreateSongFromFolder(DirectoryInfo path, out Song? result) {
      if (path.IsNullOrDoesNotExist()) {
        result = default;
        return false;
      }

      var infoFile = _GetInfoFile(path);
      if (infoFile.IsNullOrDoesNotExist()) {
        result = default;
        return false;
      }

      result = new Song(path);
      return true;
    }

  }

}
