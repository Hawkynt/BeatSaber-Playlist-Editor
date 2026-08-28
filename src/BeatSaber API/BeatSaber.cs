using System;
using System.IO;

namespace BeatSaberAPI;

public partial class BeatSaberInstallation(DirectoryInfo gameDirectory) : IBeatSaberInstallation {

  private DirectoryInfo _DataDirectory => gameDirectory.Directory("Beat Saber_Data");
  private DirectoryInfo _SongDirectory => this._DataDirectory.Directory("CustomLevels");
  private DirectoryInfo _PlaylistDirectory => gameDirectory.Directory("Playlists");
  public IPlaylistCollection Playlists => new PlaylistCollection(this._PlaylistDirectory);
  public ISongCollection Songs => new SongCollection(this._SongDirectory);

  public static BeatSaberInstallation FromGameDirectory(DirectoryInfo gameDirectory) {
    if (gameDirectory.IsNullOrDoesNotExist())
      throw new DirectoryNotFoundException("Could not find the selected Beat Saber directory.");

    if (!gameDirectory.Directory("Beat Saber_Data").Exists)
      throw new InvalidDataException("The selected directory is not a PC Beat Saber installation (Beat Saber_Data is missing).");

    return new BeatSaberInstallation(gameDirectory);
  }

  public static QuestBeatSaberInstallation FromQuest(string? adbPath = null, string? serial = null)
    => new(adbPath, serial);
}
