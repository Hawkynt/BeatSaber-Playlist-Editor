using System.Drawing;

namespace BeatSaberAPI; 

public interface IPlaylist { 
  string Name { get; set; }
  string? Author { get; set; }
  string? Description { get; set; }
  Image? Image { get; }
  IPlaylistEntryCollection Songs { get; }
  IPlaylistEntry CreateEntry(ISong song, string? displayName = null);
  void WriteToDisk();
  void SetImage(Image? image);
}

