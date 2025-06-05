using System.Collections;

namespace BeatSaberAPI; 

partial class BeatSaberInstallation {
  private class PlaylistEntryCollection(IEnumerable<IPlaylistEntry> entries) : IPlaylistEntryCollection {
    private readonly List<IPlaylistEntry> _entries = new(entries);

    public IEnumerator<IPlaylistEntry> GetEnumerator() => this._entries.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public void Add(IPlaylistEntry entry) => this._entries.Add(entry);
    public void InsertAt(int index, IPlaylistEntry entry) => this._entries.Insert(index, entry);
    public void RemoveAt(int index) => this._entries.RemoveAt(index);
    public void Clear() => this._entries.Clear();
    public bool ContainsByName(string name) => this._entries.Any(i => i.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    public bool ContainsByHash(string hash) => this._entries.Any(i => i.Sha1Hash.Equals(hash, StringComparison.OrdinalIgnoreCase));

  }

}

