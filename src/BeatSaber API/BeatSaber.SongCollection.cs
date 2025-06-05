using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace BeatSaberAPI; 

partial class BeatSaberInstallation {

  private class SongCollection(DirectoryInfo root) : ISongCollection {

    public IEnumerator<ISong> GetEnumerator() {
      foreach (var directory in root.GetDirectories(SearchOption.AllDirectories))
        if(Song.TryCreateSongFromFolder(directory,out var result))
          yield return result!;
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
  }

}

