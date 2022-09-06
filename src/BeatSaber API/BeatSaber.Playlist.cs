using System.Diagnostics;
using System.Text.Json;
using BeatSaberAPI.JSON;

namespace BeatSaberAPI; 

partial class BeatSaberInstallation {

  [DebuggerDisplay($"{{{nameof(Name)}}}")]
  private class Playlist : IPlaylist {
    private readonly System.Lazy<PlaylistFile.Root> _data;
    private readonly System.Lazy<PlaylistEntryCollection> _entries;

    private PlaylistFile.Root _Data => _data.Value;

    private Playlist(FileInfo file,Func<PlaylistFile.Root> rootFactory) {
      this.File = file;
      this._data = new(rootFactory);
      this._entries = new(this._CreateEntryCollection);
    }

    private Playlist(FileInfo file) : this(file, ()=>_ReadMetadata(file)) { }
    private Playlist(PlaylistFile.Root root,FileInfo file) : this(file, () => root) { }

    public FileInfo File { get; private set; }
    public string Name => this._Data.PlaylistTitle;
    public string Author {
      get=> this._Data.PlaylistAuthor;
      set => this._Data.PlaylistAuthor = value;
    }

    public IPlaylistEntryCollection Songs => this._entries.Value;

    private PlaylistEntryCollection _CreateEntryCollection()=> new PlaylistEntryCollection(this._Data.Songs.Select(s => new PlaylistEntry(s.SongName, s.Hash)));


    private static PlaylistFile.Root _ReadMetadata(FileInfo file) {
      using var fileStream = file.OpenRead();
      return JsonSerializer.Deserialize<PlaylistFile.Root>(fileStream);
    }

    public void WriteToDisk() {
      var root = this._Data;
      root.Songs.Clear();
      foreach (var entry in this.Songs)
        root.Songs.Add(new PlaylistFile.Song { Hash = entry.Sha1Hash.ToUpperInvariant(), SongName = entry.Name });

      this._RenameFileIfNeeded();
      using var fileStream = this.File.OpenWrite();
      JsonSerializer.Serialize(fileStream, root,options: new JsonSerializerOptions {WriteIndented=true });
      fileStream.SetLength(fileStream.Position);
    }

    private void _RenameFileIfNeeded() {
      var name = this.Name;
      var file = this.File;
      var fileName = file.GetFilenameWithoutExtension();
      if (name == fileName) 
        return;

      var directory = file.Directory;
      var extension = file.Extension;
      var newFile = directory.File($"{name}{extension}");
      var index = 1;
      while (newFile.Exists) 
        newFile = directory.File($"{name}[{++index}]{extension}");

      if (!file.Exists) {
        this.File = newFile;
        return;
      }

      file.MoveTo(newFile);
      this.File = newFile;
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

    public static Playlist Create(string name, FileInfo file) => new Playlist(
      new PlaylistFile.Root { 
        PlaylistTitle = name,
        Songs=new List<PlaylistFile.Song>()
      }, file
    );

  }

}

