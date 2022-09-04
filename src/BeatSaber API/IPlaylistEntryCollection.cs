namespace BeatSaberAPI; 

public interface IPlaylistEntryCollection : IEnumerable<IPlaylistEntry> {
  void Add(IPlaylistEntry entry);
  void Clear();
  void ContainsByHash(string hash);
  void ContainsByName(string name);
  void InsertAt(int index, IPlaylistEntry entry);
  void RemoveAt(int index);
}

