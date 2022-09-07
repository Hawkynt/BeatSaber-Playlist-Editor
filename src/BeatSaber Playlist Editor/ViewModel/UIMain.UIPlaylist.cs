using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using BeatSaber_Playlist_Editor.Properties;
using BeatSaberAPI;

namespace BeatSaber_Playlist_Editor.ViewModel;
partial class UIMain {

  [DebuggerDisplay($"{{{nameof(Name)}}}")]
  public class UIPlaylist : INotifyPropertyChanged {

    [Browsable(false)]
    public IPlaylist Source { get; }

    public string Name {
      get => this.Source.Name;
      set => this.Source.Name = value;
    }

    public string? Author { 
      get => this.Source.Author;
      set => this.Source.Author=value;
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public string CoverDetails => this._cover.Value == null ? "No image" : $"{this.Cover.Width} x {this.Cover.Height}";

    [EditorBrowsable(EditorBrowsableState.Never)]
    public Image Cover {
      get {
        return this._cover.Value ?? Resources.NoPictureAvailable;
      }
      set {
        if (value == this.Cover)
          return;

        this.Source.SetImage(value);
        this._cover = new System.Lazy<Image?>(() => this.Source.Image);
        this._OnPropertyChanged();
      }
    }

    private System.Lazy<Image?> _cover;

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void _OnPropertyChanged([CallerMemberName] string? propertyName = null) => this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName!));

    public UIPlaylist(IPlaylist source) {
      this.Source = source;
      this._cover = new System.Lazy<Image?>(() => source.Image);
    }
  }

}
