using System.Diagnostics;
using System.Text.Json;
using BeatSaber_Playlist_Editor.BeatSaberInstallation.JSON;

namespace BeatSaber_Playlist_Editor.BeatSaberInstallation; 
partial class BeatSaber {

  [DebuggerDisplay($"{{{nameof(Name)}}}")]
  private class Playlist : IPlaylist {
    private readonly FileInfo _file;
    private readonly System.Lazy<PlaylistFile.Root> _data;

    private PlaylistFile.Root _Data => _data.Value;

    public Playlist(FileInfo file) {
      _file = file;
      this._data = new System.Lazy<PlaylistFile.Root>(this._ReadMetadata);
    }

    public string Name => this._Data.PlaylistTitle;

    public IPlaylistEntryCollection Songs => new PlaylistEntryCollection(this._Data.Songs.Select(s => new PlaylistEntry(s.SongName, s.Hash)));

    private PlaylistFile.Root _ReadMetadata() {
      using var fileStream = this._file.OpenRead();
      return JsonSerializer.Deserialize<PlaylistFile.Root>(fileStream);
    }

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

