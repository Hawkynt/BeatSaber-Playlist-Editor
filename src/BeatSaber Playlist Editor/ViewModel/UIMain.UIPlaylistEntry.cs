using System.ComponentModel;
using System.Diagnostics;
using BeatSaberAPI;

namespace BeatSaber_Playlist_Editor.ViewModel;
partial class UIMain {
  
  [DebuggerDisplay($"{{{nameof(Name)}}}")]
  public class UIPlaylistEntry {

    [Browsable(false)]
    public IPlaylistEntry Source { get; }

    public string Name => this.Source.Name;

    public UIPlaylistEntry(IPlaylistEntry source) => this.Source = source;
  }

}
