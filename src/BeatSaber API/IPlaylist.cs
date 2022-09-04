namespace BeatSaberAPI; 

public interface IPlaylist { 
  string Name { get; }
  string Author { get; set; }
  IPlaylistEntryCollection Songs { get; }
  IPlaylistEntry CreateEntry(ISong song, string? displayName = null);
  void WriteToDisk();
}

