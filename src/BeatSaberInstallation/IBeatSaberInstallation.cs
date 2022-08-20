namespace BeatSaber_Playlist_Editor.BeatSaberInstallation {
  interface IBeatSaberInstallation {
    IPlaylistCollection Playlists { get; }
    ISongCollection Songs { get; }
  }

}
