using System.Diagnostics;
using System.Text.Json;
using BeatSaber_Playlist_Editor.BeatSaberInstallation.JSON;

namespace BeatSaber_Playlist_Editor.BeatSaberInstallation; 
partial class BeatSaber {

  [DebuggerDisplay($"{{{nameof(Name)}}}")]
  private class Playlist : IPlaylist {
    private readonly FileInfo _file;
    private readonly System.Lazy<PlaylistFile.Root> _data;
    private readonly System.Lazy<PlaylistEntryCollection> _entries;

    private PlaylistFile.Root _Data => _data.Value;

    public Playlist(FileInfo file) {
      _file = file;
      this._data = new (this._ReadMetadata);
      this._entries = new(this._CreateEntryCollection);
    }

    public string Name => this._Data.PlaylistTitle;

    public IPlaylistEntryCollection Songs => this._entries.Value;

    private PlaylistEntryCollection _CreateEntryCollection()=> new PlaylistEntryCollection(this._Data.Songs.Select(s => new PlaylistEntry(s.SongName, s.Hash)));


    private PlaylistFile.Root _ReadMetadata() {
      using var fileStream = this._file.OpenRead();
      return JsonSerializer.Deserialize<PlaylistFile.Root>(fileStream);
    }

    public void WriteToDisk() {
      var root = this._Data;
      root.Songs.Clear();
      foreach (var entry in this.Songs)
        root.Songs.Add(new PlaylistFile.Song { Hash = entry.Sha1Hash.ToUpperInvariant(), SongName = entry.Name });

      using var fileStream = this._file.OpenWrite();
      JsonSerializer.Serialize(fileStream, root,options: new JsonSerializerOptions {WriteIndented=true });
    }

    public IPlaylistEntry CreateEntry(ISong song, string? displayName = null) => new PlaylistEntry(displayName ?? $"{song.Artist} - {song.Title}", song.CalculateChecksum());

    public static bool TryCreatePlaylistFromFile(FileInfo source,out Playlist? result) {
      if (source.IsNullOrDoesNotExist()) {
        result = default;
        return false;
      }
              
      result = new Playlist(source);
      return true;
    }

  }

}

