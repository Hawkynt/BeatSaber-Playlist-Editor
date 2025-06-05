using System.Collections.Generic;

namespace BeatSaberAPI; 

public interface IPlaylistCollection :IEnumerable<IPlaylist> {
  IPlaylist Create(string name);
  void Delete(string name);
}

