namespace EditorTests;

using System.Collections;
using System.Collections.Generic;
using BeatSaberAPI;

public partial class Tests {
  private class PlaylistCollectionMock : IPlaylistCollection {
    public IPlaylist Create(string name) => throw new NotImplementedException();
    public void Delete(string name) => throw new NotImplementedException();
    public IEnumerator<IPlaylist> GetEnumerator() => this._playlists.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

    private readonly IEnumerable<IPlaylist> _playlists;

    public PlaylistCollectionMock(IEnumerable<IPlaylist> playlists) => this._playlists = playlists;
  }


}