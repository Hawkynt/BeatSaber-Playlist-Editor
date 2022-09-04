namespace BeatSaberAPI.BeatSaberInstallation {
  public interface IBeatSaberInstallation {
    IPlaylistCollection Playlists { get; }
    ISongCollection Songs { get; }
  }

}
