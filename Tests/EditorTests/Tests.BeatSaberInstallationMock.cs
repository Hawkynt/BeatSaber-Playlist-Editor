namespace EditorTests;
using BeatSaberAPI;

public partial class Tests {
  private class BeatSaberInstallationMock : IBeatSaberInstallation {
    public IPlaylistCollection Playlists { get; }
    public ISongCollection Songs { get; }

    public BeatSaberInstallationMock(IPlaylistCollection playlists, ISongCollection songs) {
      this.Playlists = playlists;
      this.Songs = songs;
    }
  }


}