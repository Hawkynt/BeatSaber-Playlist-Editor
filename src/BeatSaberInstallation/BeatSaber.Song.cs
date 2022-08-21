using System.Security.Cryptography;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using BeatSaber_Playlist_Editor.BeatSaberInstallation.JSON;
using System.Collections;

namespace BeatSaber_Playlist_Editor.BeatSaberInstallation; 
partial class BeatSaber {

  [DebuggerDisplay($"{{{nameof(Artist)}}} - {{{nameof(Title)}}}")]
  private class Song : ISong {

    private readonly System.Lazy<SongInfo.Root> _data;

    public DirectoryInfo Directory { get; }
    private SongInfo.Root _Data => _data.Value;
    public string Title => this._Data.SongName;
    public string? Artist => this._Data.SongAuthorName.DefaultIfNullOrWhiteSpace();
    public bool SupportsStandardMode => this._Data.DifficultyBeatmapSets.Any(i => i.BeatmapCharacteristicName.Equals("Standard", StringComparison.OrdinalIgnoreCase));
    public bool SupportsOneSaberMode => this._Data.DifficultyBeatmapSets.Any(i => i.BeatmapCharacteristicName.Equals("OneSaber", StringComparison.OrdinalIgnoreCase));
    public bool SupportsNoArrowsMode => this._Data.DifficultyBeatmapSets.Any(i => i.BeatmapCharacteristicName.Equals("NoArrows", StringComparison.OrdinalIgnoreCase));
    public bool Supports90DegreesMode => this._Data.DifficultyBeatmapSets.Any(i => i.BeatmapCharacteristicName.Equals("90Degree", StringComparison.OrdinalIgnoreCase));
    public bool Supports360DegreesMode => this._Data.DifficultyBeatmapSets.Any(i => i.BeatmapCharacteristicName.Equals("360Degree", StringComparison.OrdinalIgnoreCase));
    public GameMode SupportedGameModes =>
      (this.SupportsStandardMode ? GameMode.Normal : 0)
      | (this.SupportsOneSaberMode ? GameMode.OneSaber : 0)
      | (this.SupportsNoArrowsMode ? GameMode.NoArrows : 0)
      | (this.Supports90DegreesMode ? GameMode.NinetyDegrees : 0)
      | (this.Supports360DegreesMode ? GameMode.ThreeSixtyDegrees : 0)
      ;

    public IReadOnlyDictionary<GameMode,DifficultyMode> Difficulties { get {
        var result=new Dictionary<GameMode,DifficultyMode>();
        foreach(var mode in this._Data.DifficultyBeatmapSets) {
          var gameMode= mode.BeatmapCharacteristicName.ToLowerInvariant() switch {
            "standard"=>GameMode.Normal,
            "onesaber"=>GameMode.OneSaber,
            "noarrows"=>GameMode.NoArrows,
            "90degree"=>GameMode.NinetyDegrees,
            "360degree"=>GameMode.ThreeSixtyDegrees,
            _=>(GameMode)(-1)
          };
          if ((int)gameMode == -1)
            continue;

          DifficultyMode value = 0;
          foreach(var difficulty in mode.DifficultyBeatmaps) 
            value |= difficulty.Difficulty.ToLowerInvariant() switch {
              "easy"=>DifficultyMode.Easy,
              "normal"=>DifficultyMode.Normal,
              "hard"=>DifficultyMode.Hard,
              "expert"=>DifficultyMode.Expert,
              "expertplus"=>DifficultyMode.ExpertPlus,
              _ => 0
            };
          
          result.Add(gameMode, value);
        }
        return result;
      } }

    public Song(DirectoryInfo directory) {
      this.Directory = directory;
      this._data = new (this._ReadMetadata);
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

    public string CalculateChecksum() {
      var sb = new StringBuilder();
      _AddFileToBuilder(sb, _GetInfoFile(this.Directory));
      foreach (var set in this._Data.DifficultyBeatmapSets)
        foreach (var map in set.DifficultyBeatmaps)
          _AddFileToBuilder(sb, this.Directory.File(map.BeatmapFilename));

      var str = sb.ToString();
      using var crypto = SHA1.Create();
      return crypto.ComputeHash(Encoding.UTF8.GetBytes(str)).ToHex(true);
    }

    private static void _AddFileToBuilder(StringBuilder builder, FileInfo textFile) 
      => builder.Append(textFile.ReadAllText(Encoding.UTF8))
    ;

    public Image? GetCover() => this._ReadCover();

    private static FileInfo? _GetInfoFile(DirectoryInfo source) => source.File("Info.dat");

    private SongInfo.Root _ReadMetadata() {
      using var fileStream = _GetInfoFile(this.Directory).OpenRead();
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

    public static bool TryCreateSongFromFolder(DirectoryInfo path,out Song? result) {
      if (path.IsNullOrDoesNotExist()) {
        result = default;
        return false;
      }

      var infoFile=_GetInfoFile(path);
      if(infoFile.IsNullOrDoesNotExist()) {
        result = default;
        return false;
      }

      result = new Song(path);
      return true;
    }

  }

}

