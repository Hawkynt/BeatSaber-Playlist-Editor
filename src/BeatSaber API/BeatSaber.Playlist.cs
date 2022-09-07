using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text.Json;
using BeatSaberAPI.JSON;

namespace BeatSaberAPI;

partial class BeatSaberInstallation {

  [DebuggerDisplay($"{{{nameof(Name)}}}")]
  private class Playlist : IPlaylist {
    private readonly System.Lazy<PlaylistFile.Root> _data;
    private readonly System.Lazy<PlaylistEntryCollection> _entries;

    private PlaylistFile.Root _Data => _data.Value;

    private Playlist(FileInfo file, Func<PlaylistFile.Root> rootFactory) {
      this.File = file;
      this._data = new(rootFactory);
      this._entries = new(this._CreateEntryCollection);
    }

    private Playlist(FileInfo file) : this(file, () => _ReadMetadata(file)) { }
    private Playlist(PlaylistFile.Root root, FileInfo file) : this(file, () => root) { }

    public FileInfo File { get; private set; }
    public string Name => this._Data.PlaylistTitle ?? string.Empty;
    public string? Author {
      get => this._Data.PlaylistAuthor;
      set => this._Data.PlaylistAuthor = value;
    }

    public IPlaylistEntryCollection Songs => this._entries.Value;

    public Image? Image {
      get => _LoadImage(this._Data.Image);
      private set => this._Data.Image = _SaveImage(value);
    }

    private static Image? _LoadImage(string? data) {
      if (data.IsNullOrWhiteSpace())
        return null;

      var base64 = data!;
      if (data.StartsWith("data:image/")) {
        var index = data.IndexOf("base64,");
        if (index < 0)
          return null;

        base64 = data.Substring(index + 7);
      }

      var bytes = Convert.FromBase64String(base64);
      using var ms = new MemoryStream(bytes, 0, bytes.Length);
      return Image.FromStream(ms, true);
    }

    private static string _SaveImage(Image? image) {
      if (image == null)
        return string.Empty;

      var rawFormat = image.RawFormat;
      string mimeType = string.Empty;
      for (; ; ) {
        var rawGuid = rawFormat.Guid;
        if (rawGuid == ImageFormat.Bmp.Guid) {
          mimeType = "image/bmp";
          break;
        }
        if (rawGuid == ImageFormat.Jpeg.Guid) {
          mimeType = "image/jpeg";
          break;
        }
        if (rawGuid == ImageFormat.Png.Guid) {
          mimeType = "image/png";
          break;
        }
        if (rawGuid == ImageFormat.Tiff.Guid) {
          mimeType = "image/tiff";
          break;
        }
        if (rawGuid == ImageFormat.Gif.Guid) {
          mimeType = "image/gif";
          break;
        }
        if (rawGuid == ImageFormat.Icon.Guid) {
          mimeType = "image/x-icon";
          break;
        }
        if (rawGuid == ImageFormat.Wmf.Guid) {
          mimeType = "windows/metafile";
          break;
        }
        if (rawGuid == ImageFormat.MemoryBmp.Guid) {
          mimeType = "image/bmp";
          break;
        }

        using var ms = new MemoryStream();
        image.Save(ms, ImageFormat.Png);
        return $"data:image/png;base64,{Convert.ToBase64String(ms.ToArray())}";
      }

      using var ms2 = new MemoryStream();
      image.Save(ms2, rawFormat);
      return $"data:{mimeType};base64,{Convert.ToBase64String(ms2.ToArray())}";
    }

    private PlaylistEntryCollection _CreateEntryCollection() => new PlaylistEntryCollection(this._Data.Songs!.Select(s => new PlaylistEntry(s.SongName!, s.Hash!)));

    private static PlaylistFile.Root _ReadMetadata(FileInfo file) {
      using var fileStream = file.OpenRead();
      var result = JsonSerializer.Deserialize<PlaylistFile.Root>(fileStream)!;
      if (result.Songs == null)
        result.Songs = new();

      return result;
    }

    public void WriteToDisk() {
      var root = this._Data;
      root.Songs!.Clear();
      foreach (var entry in this.Songs)
        root.Songs!.Add(new PlaylistFile.Song { Hash = entry.Sha1Hash.ToUpperInvariant(), SongName = entry.Name });

      this._RenameFileIfNeeded();
      using var fileStream = this.File.OpenWrite();
      JsonSerializer.Serialize(fileStream, root, options: new JsonSerializerOptions { WriteIndented = true });
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

    public static bool TryCreatePlaylistFromFile(FileInfo source, out Playlist? result) {
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
        Songs = new List<PlaylistFile.Song>()
      }, file
    );

    public void SetImage(Image? image) {
      if (image == null) {
        this.Image = null;
        return;
      }
      if (image.Width > 256 || image.Height > 256) {
        using var img= image.Resize(256);
        this.Image = img;
        return;
      }

      this.Image = image;
    }
  }

}

