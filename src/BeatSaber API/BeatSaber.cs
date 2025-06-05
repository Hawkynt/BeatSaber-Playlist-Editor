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
    if(gameDirectory.IsNotNullAndExists())
      return new BeatSaberInstallation(gameDirectory);

    throw new Exception("Can not find gameDirectory");
  }

}

