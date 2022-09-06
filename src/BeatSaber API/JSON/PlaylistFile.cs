using System.Diagnostics;
using System.Text.Json.Serialization;

namespace BeatSaberAPI.JSON; 

internal class PlaylistFile {
  // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
  [DebuggerDisplay($"{{{nameof(PlaylistTitle)}}}")]
  public class Root {
    [JsonPropertyName("playlistTitle")]
    public string? PlaylistTitle { get; set; }

    [JsonPropertyName("playlistAuthor")]
    public string? PlaylistAuthor { get; set; }

    [JsonPropertyName("playlistDescription")]
    public string? PlaylistDescription { get; set; }

    [JsonPropertyName("songs")]
    public List<Song>? Songs { get; set; }

    [JsonPropertyName("image")]
    public string? Image { get; set; }
  }

  [DebuggerDisplay($"{{{nameof(SongName)}}}")]
  public class Song {
    [JsonPropertyName("hash")]
    public string? Hash { get; set; } //SHA-1 hex-bytes

    [JsonPropertyName("songName")]
    public string? SongName { get; set; }
  }


}
