namespace BeatSaberAPI.BeatSaberInstallation {
  public interface IPlaylistCollection :IEnumerable<IPlaylist> {
    IPlaylist Create(string name);
    void Delete(string name);
  }

}
