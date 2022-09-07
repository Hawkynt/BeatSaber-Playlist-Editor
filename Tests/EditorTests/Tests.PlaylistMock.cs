namespace EditorTests;
using System.Drawing;
using BeatSaberAPI;

public partial class Tests {
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


}