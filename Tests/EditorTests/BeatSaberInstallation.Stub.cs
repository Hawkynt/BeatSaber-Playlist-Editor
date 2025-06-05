using System.IO;

namespace BeatSaberAPI;

public partial class BeatSaberInstallation : IBeatSaberInstallation {
  public IPlaylistCollection Playlists => throw new System.NotImplementedException();
  public ISongCollection Songs => throw new System.NotImplementedException();
  public static BeatSaberInstallation FromGameDirectory(DirectoryInfo? gameDirectory)
    => throw new System.NotImplementedException();
}