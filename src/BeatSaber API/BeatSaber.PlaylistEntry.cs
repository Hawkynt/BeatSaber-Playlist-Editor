using System.Diagnostics;

namespace BeatSaberAPI; 

partial class BeatSaberInstallation {

  [DebuggerDisplay($"{{{nameof(Name)}}}")]
  private record PlaylistEntry(string Name, string Sha1Hash) : IPlaylistEntry;

}

