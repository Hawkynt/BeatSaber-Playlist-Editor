using System.Collections;

namespace BeatSaber_Playlist_Editor.BeatSaberInstallation; 
partial class BeatSaber {
  private class PlaylistEntryCollection : IPlaylistEntryCollection {
    private readonly List<IPlaylistEntry> _entries=new();

    public PlaylistEntryCollection(IEnumerable<PlaylistEntry> entries) => this._entries.AddRange(entries);

    public IEnumerator<IPlaylistEntry> GetEnumerator() => this._entries.Cast<IPlaylistEntry>().GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

    public void Add(IPlaylistEntry entry) => this._entries.Add(entry);
    public void InsertAt(int index, IPlaylistEntry entry) => this._entries.Insert(index, entry);
    public void RemoveAt(int index) => this._entries.RemoveAt(index);
    public void Clear() => this._entries.Clear();
    public void ContainsByName(string name) => this._entries.Any(i => i.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    public void ContainsByHash(string hash) => this._entries.Any(i => i.Sha1Hash.Equals(hash, StringComparison.OrdinalIgnoreCase));

  }

}

