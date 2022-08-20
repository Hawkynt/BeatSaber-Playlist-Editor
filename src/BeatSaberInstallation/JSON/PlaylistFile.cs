﻿using System.Text.Json.Serialization;

namespace BeatSaber_Playlist_Editor.BeatSaberInstallation.JSON {
  internal class PlaylistFile {
    // Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public class Root {
      [JsonPropertyName("playlistTitle")]
      public string PlaylistTitle { get; set; }

      [JsonPropertyName("playlistAuthor")]
      public string PlaylistAuthor { get; set; }

      [JsonPropertyName("playlistDescription")]
      public string PlaylistDescription { get; set; }

      [JsonPropertyName("songs")]
      public List<Song> Songs { get; set; }

      [JsonPropertyName("image")]
      public object Image { get; set; }
    }

    public class Song {
      [JsonPropertyName("hash")]
      public string Hash { get; set; } //SHA-1 hex-bytes

      [JsonPropertyName("songName")]
      public string SongName { get; set; }
    }


  }
}
