using System.Text.Json.Serialization;

namespace BeatSaberAPI.BeatSaberInstallation.JSON {
  internal class DifficultySetting {
    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class Event {
      [JsonPropertyName("_time")]
      public double Time { get; set; }

      [JsonPropertyName("_type")]
      public int Type { get; set; }

      [JsonPropertyName("_value")]
      public int Value { get; set; }
    }

    public class Note {
      [JsonPropertyName("_time")]
      public double Time { get; set; }

      [JsonPropertyName("_lineIndex")]
      public int LineIndex { get; set; }

      [JsonPropertyName("_lineLayer")]
      public int LineLayer { get; set; }

      [JsonPropertyName("_type")]
      public int Type { get; set; }

      [JsonPropertyName("_cutDirection")]
      public int CutDirection { get; set; }
    }

    public class Obstacle {
      [JsonPropertyName("_time")]
      public double Time { get; set; }

      [JsonPropertyName("_lineIndex")]
      public int LineIndex { get; set; }

      [JsonPropertyName("_type")]
      public int Type { get; set; }

      [JsonPropertyName("_duration")]
      public double Duration { get; set; }

      [JsonPropertyName("_width")]
      public int Width { get; set; }
    }

    public class Root {
      [JsonPropertyName("_version")]
      public string Version { get; set; }

      [JsonPropertyName("_events")]
      public List<Event> Events { get; set; }

      [JsonPropertyName("_notes")]
      public List<Note> Notes { get; set; }

      [JsonPropertyName("_obstacles")]
      public List<Obstacle> Obstacles { get; set; }
    }


  }
}
