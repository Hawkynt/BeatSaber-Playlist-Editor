namespace EditorTests;

using System.Collections;
using System.Collections.Generic;
using BeatSaberAPI;

public partial class Tests {
  private class PlaylistEntryCollectionMock : IPlaylistEntryCollection {
    private readonly IEnumerable<IPlaylistEntry> _entries;

    public PlaylistEntryCollectionMock(IEnumerable<IPlaylistEntry> entries) => this._entries = entries;

    public void Add(IPlaylistEntry entry) => throw new NotImplementedException();
    public void Clear() => throw new NotImplementedException();
    public void ContainsByHash(string hash) => throw new NotImplementedException();
    public void ContainsByName(string name) => throw new NotImplementedException();
    public IEnumerator<IPlaylistEntry> GetEnumerator() => this._entries.GetEnumerator();
    public void InsertAt(int index, IPlaylistEntry entry) => throw new NotImplementedException();
    public void RemoveAt(int index) => throw new NotImplementedException();
    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
  }


}