using System.ComponentModel;
using System.Diagnostics;
using BeatSaber_Playlist_Editor.Properties;
using BeatSaberAPI;

namespace BeatSaber_Playlist_Editor.ViewModel;
partial class UIMain {
  
  [DebuggerDisplay($"{{{nameof(Artist)}}} - {{{nameof(Title)}}}")]
  public class UISong {

    [Browsable(false)]
    public ISong Source { get; }

    public string? Artist => this.Source.Artist;
    public string Title => this.Source.Title;

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string CoverDetails => this._cover.Value == null ? "No image" : $"{this.Cover.Width} x {this.Cover.Height}";

    private System.Lazy<Image?> _cover;

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Image Cover => this._cover.Value ?? Resources.NoPictureAvailable;
    
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public string? LevelAuthor => this.Source.LevelAuthor;
    
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public double BeatsPerMinute => this.Source.BeatsPerMinute;
    
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public string? Environment => this.Source.Environment;

    public UISong(ISong source) {
      this.Source = source;
      this._cover = new System.Lazy<Image?>(() => source.Image);
    }
  }

}
