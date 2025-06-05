using System;

namespace EditorTests;
using BeatSaberAPI;

public partial class Tests {
  private class PlaylistEntryMock(string name) : IPlaylistEntry {
    public string Name => name;
    public string Sha1Hash => throw new NotImplementedException();
  }


}