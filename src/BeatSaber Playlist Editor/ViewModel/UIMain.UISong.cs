using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.Versioning;
using BeatSaber_Playlist_Editor.Properties;
using BeatSaberAPI;

namespace BeatSaber_Playlist_Editor.ViewModel;
partial class UIMain {
  
  [DebuggerDisplay($"{{{nameof(Artist)}}} - {{{nameof(Title)}}}")]
  public class UISong(ISong source) {

    [Browsable(false)]
    public ISong Source { get; } = source;

    public string? Artist => this.Source.Artist;
    public string Title => this.Source.Title;

    [EditorBrowsable(EditorBrowsableState.Never)]
    [SupportedOSPlatform("windows6.1")] 
    public string CoverDetails => this._cover.Value == null ? "No image" : $"{this.Cover.Width} x {this.Cover.Height}";

    [SupportedOSPlatform("windows6.1")] 
    private readonly System.Lazy<Image?> _cover = new(() => source.Image);

    [EditorBrowsable(EditorBrowsableState.Never)]
    [SupportedOSPlatform("windows6.1")] 
    public Image Cover => this._cover.Value ?? Resources.NoPictureAvailable;
    
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public string? LevelAuthor => this.Source.LevelAuthor;
    
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public double BeatsPerMinute => this.Source.BeatsPerMinute;
    
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public string? Environment => this.Source.Environment;
  }

}
