namespace BeatSaber_Playlist_Editor.BeatSaberInstallation {
  interface IPlaylist { 
    string Name { get; }
    IPlaylistEntryCollection Songs { get; }
  }

}
