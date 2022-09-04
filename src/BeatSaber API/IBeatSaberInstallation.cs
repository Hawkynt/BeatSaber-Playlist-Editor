namespace BeatSaberAPI; 

public interface IBeatSaberInstallation {
  IPlaylistCollection Playlists { get; }
  ISongCollection Songs { get; }
}

