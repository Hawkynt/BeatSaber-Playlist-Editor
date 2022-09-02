using System.Collections;

namespace BeatSaber_Playlist_Editor.BeatSaberInstallation; 
partial class BeatSaber {

  private class PlaylistCollection : IPlaylistCollection {
    
    private readonly DirectoryInfo _root;

    public PlaylistCollection(DirectoryInfo root) => _root = root;

    public IPlaylist Create(string name) {
      if (this.Any(i => string.Equals(i.Name ,name,StringComparison.OrdinalIgnoreCase)))
        throw new ArgumentException($"Playlist {name} already exists.", nameof(name));
      
      var result = Playlist.Create(name,_root.File($"{name.SanitizeForFileName()}.json"));
      return result;
    }

    public void Delete(string name) {
      var list = this._GetLists().First(i => string.Equals(i.Name, name, StringComparison.OrdinalIgnoreCase));
      if (list != null)
        list.File.Delete();
    }

    private IEnumerable<Playlist> _GetLists() {
      foreach (var file in _root.GetFiles("*.json"))
        if (Playlist.TryCreatePlaylistFromFile(file, out var result))
          yield return result!;
    }

    public IEnumerator<IPlaylist> GetEnumerator() =>this._GetLists().GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() =>this.GetEnumerator();

  }

}

