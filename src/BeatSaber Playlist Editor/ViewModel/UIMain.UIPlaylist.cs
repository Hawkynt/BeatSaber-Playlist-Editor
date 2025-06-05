using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using BeatSaber_Playlist_Editor.Properties;
using BeatSaberAPI;

namespace BeatSaber_Playlist_Editor.ViewModel;
partial class UIMain {

  [DebuggerDisplay($"{{{nameof(Name)}}}")]
  public class UIPlaylist(IPlaylist source) : INotifyPropertyChanged {

    private static readonly Image _DEFAULT_IMAGE = Resources.NoPictureAvailable;
    
    [Browsable(false)]
    public IPlaylist Source { get; } = source;

    public string Name => this.Source.Name;
    public string? Author => this.Source.Author;
    public string? Description
    {
      get => this.Source.Description;
      set
      {
        if (value == this.Source.Description)
          return;
        this.Source.Description = value;
        this._OnPropertyChanged();
      }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    [SupportedOSPlatform("windows6.1")]
    public string CoverDetails => this._cover.Value == null ? "No image" : $"{this.Cover.Width} x {this.Cover.Height}";

    [EditorBrowsable(EditorBrowsableState.Never)]
    [SupportedOSPlatform("windows6.1")]
    public Image Cover {
      get => this._cover.Value ?? _DEFAULT_IMAGE;
      set {
        if (value == this.Cover || value == _DEFAULT_IMAGE)
          return;

        this.Source.SetImage(value);
        this._cover = new System.Lazy<Image?>(() => this.Source.Image);
        this._OnPropertyChanged();
      }
    }

    [SupportedOSPlatform("windows6.1")] 
    private System.Lazy<Image?> _cover = new(() => source.Image);

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void _OnPropertyChanged([CallerMemberName] string? propertyName = null) => this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName!));

    public void TriggerAllPropertiesChanged() {
      this._OnPropertyChanged(nameof(this.Name));
      this._OnPropertyChanged(nameof(this.Author));
      this._OnPropertyChanged(nameof(this.Description));

      if (!OperatingSystem.IsWindowsVersionAtLeast(6, 1))
        return;

#pragma warning disable CA1416 // This is a Windows-only property, so we can safely ignore this warning.
      this._OnPropertyChanged(nameof(this.Cover));
      this._OnPropertyChanged(nameof(this.CoverDetails));
#pragma warning restore CA1416 // Validate platform compatibility
    }
  }

}
