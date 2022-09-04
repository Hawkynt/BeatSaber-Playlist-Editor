using System.Diagnostics;

namespace BeatSaberAPI; 

partial class BeatSaberInstallation {

  [DebuggerDisplay($"{{{nameof(Name)}}}")]
  private class PlaylistEntry : IPlaylistEntry {
    public string Name { get; }

    public string Sha1Hash { get; }

    public PlaylistEntry(string name, string sha1Hash) {
      Name = name;
      Sha1Hash = sha1Hash;
    }

  }

}

