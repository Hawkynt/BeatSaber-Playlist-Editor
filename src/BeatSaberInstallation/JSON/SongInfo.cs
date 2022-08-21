using System.Diagnostics;
using System.Text.Json.Serialization;

namespace BeatSaber_Playlist_Editor.BeatSaberInstallation.JSON {
  internal class SongInfo {
    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class Beatsage {
      [JsonPropertyName("version")]
      public string Version { get; set; }

      [JsonPropertyName("id")]
      public string Id { get; set; }

      [JsonPropertyName("events")]
      public List<string> Events { get; set; }
    }

    public class CustomData {
      [JsonPropertyName("_editors")]
      public Editors Editors { get; set; }
    }

    [DebuggerDisplay($"{{{nameof(Difficulty)}}}")]
    public class DifficultyBeatmap {
      [JsonPropertyName("_difficulty")]
      public string Difficulty { get; set; }

      [JsonPropertyName("_difficultyRank")]
      public int DifficultyRank { get; set; }

      [JsonPropertyName("_beatmapFilename")]
      public string BeatmapFilename { get; set; }

      [JsonPropertyName("_noteJumpMovementSpeed")]
      public double NoteJumpMovementSpeed { get; set; }

      [JsonPropertyName("_noteJumpStartBeatOffset")]
      public double NoteJumpStartBeatOffset { get; set; }
    }

    [DebuggerDisplay($"{{{nameof(BeatmapCharacteristicName)}}}")]
    public class DifficultyBeatmapSet {
      [JsonPropertyName("_beatmapCharacteristicName")]
      public string BeatmapCharacteristicName { get; set; }

      [JsonPropertyName("_difficultyBeatmaps")]
      public List<DifficultyBeatmap> DifficultyBeatmaps { get; set; }
    }

    [DebuggerDisplay($"{{{nameof(LastEditedBy)}}}")]
    public class Editors {
      [JsonPropertyName("_lastEditedBy")]
      public string LastEditedBy { get; set; }

      [JsonPropertyName("beatsage")]
      public Beatsage Beatsage { get; set; }
    }

    [DebuggerDisplay($"{{{nameof(SongAuthorName)}}} - {{{nameof(SongName)}}}")]
    public class Root {
      [JsonPropertyName("_version")]
      public string Version { get; set; }

      [JsonPropertyName("_songName")]
      public string SongName { get; set; }

      [JsonPropertyName("_songSubName")]
      public string SongSubName { get; set; }

      [JsonPropertyName("_songAuthorName")]
      public string SongAuthorName { get; set; }

      [JsonPropertyName("_levelAuthorName")]
      public string LevelAuthorName { get; set; }

      [JsonPropertyName("_beatsPerMinute")]
      public double BeatsPerMinute { get; set; }

      [JsonPropertyName("_songTimeOffset")]
      public double SongTimeOffset { get; set; }

      [JsonPropertyName("_shuffle")]
      public double Shuffle { get; set; }

      [JsonPropertyName("_shufflePeriod")]
      public double ShufflePeriod { get; set; }

      [JsonPropertyName("_previewStartTime")]
      public double PreviewStartTime { get; set; }

      [JsonPropertyName("_previewDuration")]
      public double PreviewDuration { get; set; }

      [JsonPropertyName("_songFilename")]
      public string SongFilename { get; set; }

      [JsonPropertyName("_coverImageFilename")]
      public string CoverImageFilename { get; set; }

      [JsonPropertyName("_environmentName")]
      public string EnvironmentName { get; set; }

      [JsonPropertyName("_allDirectionsEnvironmentName")]
      public string AllDirectionsEnvironmentName { get; set; }

      [JsonPropertyName("_difficultyBeatmapSets")]
      public List<DifficultyBeatmapSet> DifficultyBeatmapSets { get; set; }

      [JsonPropertyName("_customData")]
      public CustomData CustomData { get; set; }
    }


  }
}
