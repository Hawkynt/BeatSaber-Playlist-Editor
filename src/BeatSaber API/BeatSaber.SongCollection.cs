using System.Collections;

namespace BeatSaberAPI; 

partial class BeatSaberInstallation {

  private class SongCollection : ISongCollection {

    private readonly DirectoryInfo _root;

    public SongCollection(DirectoryInfo root) {
      _root = root;
    }

    public IEnumerator<ISong> GetEnumerator() {
      foreach (var directory in _root.GetDirectories(SearchOption.AllDirectories))
        if(Song.TryCreateSongFromFolder(directory,out var result))
          yield return result!;
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
  }

}

