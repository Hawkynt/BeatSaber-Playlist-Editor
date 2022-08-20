using System.Collections;

namespace BeatSaber_Playlist_Editor.BeatSaberInstallation; 
partial class BeatSaber {

  private class PlaylistCollection : IPlaylistCollection {
    
    private readonly DirectoryInfo _root;

    public PlaylistCollection(DirectoryInfo root) => _root = root;

    public IEnumerator<IPlaylist> GetEnumerator() {
      foreach (var file in _root.GetFiles("*.json"))
        if (Playlist.TryCreatePlaylistFromFile(file, out var result))
          yield return result!;
    }

    IEnumerator IEnumerable.GetEnumerator() =>this.GetEnumerator();
  }

}

