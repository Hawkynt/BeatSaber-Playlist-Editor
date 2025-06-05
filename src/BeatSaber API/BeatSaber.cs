namespace BeatSaberAPI;
public partial class BeatSaberInstallation(DirectoryInfo gameDirectory) : IBeatSaberInstallation {

  private DirectoryInfo _DataDirectory => gameDirectory.Directory("Beat Saber_Data");
  private DirectoryInfo _SongDirectory => _DataDirectory.Directory("CustomLevels");
  private DirectoryInfo _PlaylistDirectory => gameDirectory.Directory("Playlists");
  public IPlaylistCollection Playlists => new PlaylistCollection(_PlaylistDirectory);
  public ISongCollection Songs => new SongCollection(_SongDirectory);

  public static BeatSaberInstallation FromGameDirectory(DirectoryInfo gameDirectory) {
    if(gameDirectory.IsNotNullAndExists())
      return new BeatSaberInstallation(gameDirectory);

    throw new Exception("Can not find gameDirectory");
  }

}

