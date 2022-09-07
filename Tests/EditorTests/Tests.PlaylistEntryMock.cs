namespace EditorTests;
using BeatSaberAPI;

public partial class Tests {
  private class PlaylistEntryMock : IPlaylistEntry {
    public string Name { get; }
    public string Sha1Hash => throw new NotImplementedException();

    public PlaylistEntryMock(string name) => this.Name = name;
  }


}