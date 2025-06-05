using System.Collections.Generic;

namespace BeatSaberAPI; 

public interface IPlaylistEntryCollection : IEnumerable<IPlaylistEntry> {
  void Add(IPlaylistEntry entry);
  void Clear();
  bool ContainsByHash(string hash);
  bool ContainsByName(string name);
  void InsertAt(int index, IPlaylistEntry entry);
  void RemoveAt(int index);
}

