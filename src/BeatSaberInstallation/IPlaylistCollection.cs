namespace BeatSaber_Playlist_Editor.BeatSaberInstallation {
  interface IPlaylistCollection :IEnumerable<IPlaylist> {
    IPlaylist Create(string name);
    void Delete(string name);
  }

}
