using System.Collections;

namespace BeatSaber_Playlist_Editor.BeatSaberInstallation; 
partial class BeatSaber {
  private class PlaylistEntryCollection : IPlaylistEntryCollection {
    private readonly List<PlaylistEntry> _entries=new();

    public PlaylistEntryCollection(IEnumerable<PlaylistEntry> entries) => this._entries.AddRange(entries);

    public IEnumerator<IPlaylistEntry> GetEnumerator() => this._entries.Cast<IPlaylistEntry>().GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
  }

}

