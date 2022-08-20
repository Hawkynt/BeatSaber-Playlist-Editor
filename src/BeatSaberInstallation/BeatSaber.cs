using System.Security.Cryptography;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.Json;
using BeatSaber_Playlist_Editor.BeatSaberInstallation.JSON;
using System.Collections;

namespace BeatSaber_Playlist_Editor.BeatSaberInstallation {

  interface IBeatSaberInstallation {
    IPlaylistCollection Playlists { get; }
    ISongCollection Songs { get; }
  }

  interface IPlaylistCollection:IEnumerable<IPlaylist> {  }

  interface ISongCollection:IEnumerable<ISong> { }

  interface IPlaylist { 
    string Name { get; }
  }

  interface ISong { 
    string Title { get;}
    string? Artist { get; }
  }

  internal class BeatSaber {

    #region nested types

    private class Song : ISong {

      private readonly System.Lazy<SongInfo.Root> _data;

      public DirectoryInfo Directory { get; }
      private SongInfo.Root _Data => _data.Value;

      public string Title => this._Data.SongName;
      public string? Artist => this._Data.SongAuthorName.DefaultIfNullOrWhiteSpace();

      public Song(DirectoryInfo directory) {
        this.Directory = directory;
        this._data = new System.Lazy<SongInfo.Root>(this._ReadMetadata);
      }

      public FileInfo? GetCoverFile() {
        var coverFileName = this._Data.CoverImageFilename;
        if (coverFileName.IsNullOrWhiteSpace())
          return null;

        return this.Directory.File(coverFileName);
      }

      public FileInfo? GetSongFile() {
        var songFileName = this._Data.SongFilename;
        if (songFileName.IsNullOrWhiteSpace())
          return null;

        return this.Directory.File(songFileName);
      }

      public byte[] CalculateChecksum() {
        var sb = new StringBuilder();
        _AddFileToBuilder(sb, this._GetInfoFile());
        foreach (var set in this._Data.DifficultyBeatmapSets)
          foreach (var map in set.DifficultyBeatmaps)
            _AddFileToBuilder(sb, this.Directory.File(map.BeatmapFilename));

        var str = sb.ToString();
        using var crypto = SHA1.Create();
        return crypto.ComputeHash(Encoding.UTF8.GetBytes(str));
      }

      private static void _AddFileToBuilder(StringBuilder builder,FileInfo textFile) {
        builder.Append(textFile.ReadAllText(Encoding.UTF8));
      }

      public Image? GetCover() => this._ReadCover();

      private FileInfo? _GetInfoFile() => this.Directory.File("Info.dat");

      private SongInfo.Root _ReadMetadata() {
        using var fileStream = this._GetInfoFile().OpenRead();
        return JsonSerializer.Deserialize<SongInfo.Root>(fileStream);
      }

      private Image? _ReadCover() {
        var coverFile = this.GetCoverFile();
        if (coverFile.NotExists())
          return null;

        try {
          var image = Image.FromFile(coverFile.FullName);
          return image;
        } catch (Exception e){
          Trace.WriteLine($"{nameof(_ReadCover)}:Error loading cover '{coverFile.FullName}': {e}");
          return null;
        }
      }

    }

    private class SongCollection : ISongCollection {

      private readonly DirectoryInfo _root;

      public SongCollection(DirectoryInfo root) {
        _root = root;
      }

      public IEnumerator<ISong> GetEnumerator() {
        throw new NotImplementedException();
      }

      IEnumerator IEnumerable.GetEnumerator() {
        throw new NotImplementedException();
      }
    }

    #endregion

    private readonly DirectoryInfo _gameDirectory;

    private DirectoryInfo _DataDirectory => _gameDirectory.Directory("Beat Saber_Data");
    private DirectoryInfo _SongDirectory => _DataDirectory.Directory("CustomLevels");
    private DirectoryInfo _PaylistDirectory => _gameDirectory.Directory("Paylists");

    public BeatSaber(DirectoryInfo gameDirectory) {
      _gameDirectory = gameDirectory;
    }

    public static BeatSaber FromGameDirectory(DirectoryInfo gameDirectory) {
      if(gameDirectory.IsNotNullAndExists())
        return new BeatSaber(gameDirectory);

      throw new Exception("Can not find gameDirectory");
    }

  }

}
