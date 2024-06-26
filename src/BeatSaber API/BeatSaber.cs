﻿namespace BeatSaberAPI;
public partial class BeatSaberInstallation:IBeatSaberInstallation {

  private readonly DirectoryInfo _gameDirectory;

  private DirectoryInfo _DataDirectory => _gameDirectory.Directory("Beat Saber_Data");
  private DirectoryInfo _SongDirectory => _DataDirectory.Directory("CustomLevels");
  private DirectoryInfo _PlaylistDirectory => _gameDirectory.Directory("Playlists");
  public IPlaylistCollection Playlists => new PlaylistCollection(this._PlaylistDirectory);
  public ISongCollection Songs => new SongCollection(this._SongDirectory);

  public BeatSaberInstallation(DirectoryInfo gameDirectory) => _gameDirectory = gameDirectory;

  public static BeatSaberInstallation FromGameDirectory(DirectoryInfo gameDirectory) {
    if(gameDirectory.IsNotNullAndExists())
      return new BeatSaberInstallation(gameDirectory);

    throw new Exception("Can not find gameDirectory");
  }

}

