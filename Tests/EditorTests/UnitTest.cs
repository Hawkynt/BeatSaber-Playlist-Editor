namespace EditorTests;

using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using BeatSaberAPI;

public class Tests {

  private class BeatSaberInstallationMock : IBeatSaberInstallation {
    public IPlaylistCollection Playlists { get; }
    public ISongCollection Songs { get; }

    public BeatSaberInstallationMock(IPlaylistCollection playlists, ISongCollection songs) {
      this.Playlists = playlists;
      this.Songs = songs;
    }
  }

  private class PlaylistCollectionMock : IPlaylistCollection {
    public IPlaylist Create(string name) => throw new NotImplementedException();
    public void Delete(string name) => throw new NotImplementedException();
    public IEnumerator<IPlaylist> GetEnumerator() => this._playlists.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

    private readonly IEnumerable<IPlaylist> _playlists;

    public PlaylistCollectionMock(IEnumerable<IPlaylist> playlists) => this._playlists = playlists;
  }

  private class PlaylistMock : IPlaylist {
    public string Name => "Unit-Test";

    public string Author { 
      get => "Hawkynt"; 
      set => throw new NotImplementedException(); 
    }

    public Image? Image {
      get => throw new NotImplementedException();
    }

    public IPlaylistEntryCollection Songs { get; }

    public PlaylistMock(IPlaylistEntryCollection songs) => this.Songs = songs;

    public IPlaylistEntry CreateEntry(ISong song, string? displayName = null) => throw new NotImplementedException();
    public void WriteToDisk() => throw new NotImplementedException();
    public void SetImage(Image? image) => throw new NotImplementedException();
  }

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

  private class PlaylistEntryMock : IPlaylistEntry {
    public string Name { get; }
    public string Sha1Hash => throw new NotImplementedException();

    public PlaylistEntryMock(string name) => this.Name = name;
  }

  private IBeatSaberInstallation _mock;

  [SetUp]
  public void Setup() {
    this._mock = new BeatSaberInstallationMock(
      new PlaylistCollectionMock(new[] {
        new PlaylistMock(new PlaylistEntryCollectionMock(new[] {
          new PlaylistEntryMock("a"),
          new PlaylistEntryMock("b"),
          new PlaylistEntryMock("c")
        }))
      }),
      null
      );
  }

  [Test]
  public void TestOneUpOrdering() {
    // TODO:
    Assert.Pass();
  }

  [Test]
  public void TestOneDownOrdering() {
    // TODO:
    Assert.Pass();
  }

  [Test]
  public void TestMoveToFirstOrdering() {
    // TODO:
    Assert.Pass();
  }

  [Test]
  public void TestMoveToLastOrdering() {
    // TODO:
    Assert.Pass();
  }


}