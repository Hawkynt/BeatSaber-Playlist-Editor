using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BeatSaberAPI;

partial class BeatSaberInstallation {

  private static readonly string[] PLAYLIST_EXTENSIONS = ["*.json", "*.bplist", "*.blist"];

  private class PlaylistCollection(DirectoryInfo root) : IPlaylistCollection {

    public IPlaylist Create(string name) {
      root.Create();
      if (this.Any(i => string.Equals(i.Name, name, StringComparison.OrdinalIgnoreCase)))
        throw new ArgumentException($"Playlist {name} already exists.", nameof(name));

      return Playlist.Create(name, root.File($"{name.SanitizeForFileName()}.json"));
    }

    public void Delete(string name) {
      var list = this._GetLists().FirstOrDefault(i => string.Equals(i.Name, name, StringComparison.OrdinalIgnoreCase));
      list?.File.Delete();
    }

    private IEnumerable<Playlist> _GetLists() {
      if (!root.Exists)
        yield break;

      foreach (var pattern in PLAYLIST_EXTENSIONS)
        foreach (var file in root.GetFiles(pattern, SearchOption.AllDirectories))
          if (Playlist.TryCreatePlaylistFromFile(file, out var result))
            yield return result!;
    }

    public IEnumerator<IPlaylist> GetEnumerator() => this._GetLists().GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

  }

}
