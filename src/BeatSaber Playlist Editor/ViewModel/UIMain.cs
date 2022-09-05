using System.ComponentModel;
using System.Runtime.CompilerServices;
using BeatSaberAPI;

namespace BeatSaber_Playlist_Editor.ViewModel;
internal class UIMain : INotifyPropertyChanged {

  #region nested types

  public class UIPlaylist {
    public IPlaylist Source { get; }

    public string Name => this.Source.Name;
    public string? Author => this.Source.Author;

    public UIPlaylist(IPlaylist source) => this.Source = source;

  }

  public class UIPlayerlistEntry {
    public IPlaylistEntry Source { get; }

    public string Name => this.Source.Name;

    public UIPlayerlistEntry(IPlaylistEntry source) => this.Source = source;
  }

  public class UISong {
    public ISong Source { get; }

    public string? Artist => this.Source.Artist;
    public string Title => this.Source.Title;

    public UISong(ISong source) => this.Source = source;
  }


  #endregion

  private bool _isPlaylistsAvailable;
  private bool _isRefreshAvailable;
  private bool _isCurrentPlaylistAvailable;
  private bool _isSongsAvailable;

  public event PropertyChangedEventHandler? PropertyChanged;

  protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null) => this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

  public bool IsPlaylistsAvailable {
    get => _isPlaylistsAvailable;
    private set => this.SetProperty(this.OnPropertyChanged, ref _isPlaylistsAvailable, value);
  }

  public bool IsRefreshAvailable {
    get => _isRefreshAvailable;
    private set => this.SetProperty(this.OnPropertyChanged, ref _isRefreshAvailable, value);
  }

  public bool IsCurrentPlaylistAvailable {
    get => _isCurrentPlaylistAvailable;
    private set => this.SetProperty(this.OnPropertyChanged, ref _isCurrentPlaylistAvailable, value);
  }

  public bool IsSongsAvailable {
    get => _isSongsAvailable;
    private set => this.SetProperty(this.OnPropertyChanged, ref _isSongsAvailable, value);
  }

  public SortableBindingList<UIPlaylist> Playlists { get; } = new ();
  public SortableBindingList<UIPlayerlistEntry> CurrentPlaylistEntries { get; } = new();
  public SortableBindingList<UISong> Songs { get; } = new();

  public void SetInstallation(DirectoryInfo rootDirectory) { }
  public void Refresh() { }
  

}
