using System.ComponentModel;
using System.Runtime.CompilerServices;
using BeatSaberAPI;

namespace BeatSaber_Playlist_Editor.ViewModel;
internal class UIMain : INotifyPropertyChanged {

  #region nested types

  public class UIPlaylist {

    [Browsable(false)]
    public IPlaylist Source { get; }

    public string Name => this.Source.Name;
    public string? Author => this.Source.Author;

    public UIPlaylist(IPlaylist source) => this.Source = source;

  }

  public class UIPlayerlistEntry {

    [Browsable(false)]
    public IPlaylistEntry Source { get; }

    public string Name => this.Source.Name;

    public UIPlayerlistEntry(IPlaylistEntry source) => this.Source = source;
  }

  public class UISong {

    [Browsable(false)]
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
  private IBeatSaberInstallation? _beatSaber;
  private UIPlaylist? _currentPlaylist;
  private string? _songFilterText;
  private bool _isStandardGameModeVisible;
  private bool _isOneSaberGameModeVisible;
  private bool _isNoArrowsGameModeVisible;
  private bool _is90GameModeVisible;
  private bool _is360GameModeVisible;
  private bool _isCurrentPlaylistSaveAvailable;

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

  public bool IsCurrentPlaylistSaveAvailable {
    get => _isCurrentPlaylistSaveAvailable;
    private set => this.SetProperty(this.OnPropertyChanged, ref _isCurrentPlaylistSaveAvailable ,value);
  }

  public bool IsSongsAvailable {
    get => _isSongsAvailable;
    private set => this.SetProperty(this.OnPropertyChanged, ref _isSongsAvailable, value);
  }

  public string? SongFilterText {
    get => _songFilterText;
    set {
      if (this.SetProperty(this.OnPropertyChanged, ref _songFilterText, value))
        this.RefreshSongs();
    }
  }

  public bool IsStandardGameModeVisible {
    get => _isStandardGameModeVisible;
    set {
      if (this.SetProperty(this.OnPropertyChanged, ref _isStandardGameModeVisible, value))
        this.RefreshSongs();
    }
  }

  public bool IsOneSaberGameModeVisible {
    get => _isOneSaberGameModeVisible;
    set {
      if (this.SetProperty(this.OnPropertyChanged, ref _isOneSaberGameModeVisible, value))
        this.RefreshSongs();
    }
  }

  public bool IsNoArrowsGameModeVisible {
    get => _isNoArrowsGameModeVisible;
    set {
      if (this.SetProperty(this.OnPropertyChanged, ref _isNoArrowsGameModeVisible, value))
        this.RefreshSongs();
    }
  }

  public bool Is90GameModeVisible {
    get => _is90GameModeVisible;
    set {
      if (this.SetProperty(this.OnPropertyChanged, ref _is90GameModeVisible, value))
        this.RefreshSongs();
    }
  }

  public bool Is360GameModeVisible {
    get => _is360GameModeVisible;
    set {
      if (this.SetProperty(this.OnPropertyChanged, ref _is360GameModeVisible, value))
        this.RefreshSongs();
    }
  }

  public IBeatSaberInstallation? BeatSaber {
    get => _beatSaber;
    private set {
      if (!this.SetProperty(this.OnPropertyChanged, ref _beatSaber, value))
        return;

      this.IsRefreshAvailable = value != null;
      this.Refresh();
    }
  }

  public UIPlaylist? CurrentPlaylist {
    get => _currentPlaylist;
    set {
      if (!this.SetProperty(this.OnPropertyChanged, ref _currentPlaylist, value))
        return;

      this.CurrentPlaylistEntries.Clear();
      if (value != null)
        this.CurrentPlaylistEntries.AddRange(value.Source.Songs.Select(i => new UIPlayerlistEntry(i)));

      this.IsCurrentPlaylistAvailable = this.CurrentPlaylistEntries.Count > 0;
      this.IsCurrentPlaylistSaveAvailable = false;
    }
  }

  public void MoveUp(IEnumerable<UIPlayerlistEntry> entries) {
    var pl = this.CurrentPlaylist;
    if (pl == null)
      return;




  }

  public SortableBindingList<UIPlaylist> Playlists { get; } = new();
  public SortableBindingList<UIPlayerlistEntry> CurrentPlaylistEntries { get; } = new();
  public SortableBindingList<UISong> Songs { get; } = new();

  public void SetInstallation(DirectoryInfo? rootDirectory)
    => this.SetInstallation(rootDirectory == null ? null : BeatSaberInstallation.FromGameDirectory(rootDirectory))
  ;

  public void SetInstallation(IBeatSaberInstallation? beatSaber)
    => this.BeatSaber = beatSaber
  ;

  public void Refresh() {
    this.RefreshPlaylists();
    this.RefreshSongs();
  }

  public void RefreshSongs() {
    var bs = this.BeatSaber;
    this.Songs.Clear();
    if (bs != null) {
      IEnumerable<ISong> songs = bs.Songs;
      if (this.SongFilterText.IsNotNullOrWhiteSpace()) {
        var parts = this.SongFilterText.Split(" ").Select(i => i.Trim());
        foreach (var part in parts)
          songs = songs.Where(s => (s.Artist?.Contains(part, StringComparison.CurrentCultureIgnoreCase) ?? true) || s.Title.Contains(part, StringComparison.CurrentCultureIgnoreCase));
      }

      // TODO: somehow i'm not convinced by the game mode filter logic
      if (this.IsStandardGameModeVisible)
        songs = songs.Where(s => s.SupportedGameModes.HasFlag(GameMode.Normal));

      if (this.IsOneSaberGameModeVisible)
        songs = songs.Where(s => s.SupportedGameModes.HasFlag(GameMode.OneSaber));

      if (this.IsNoArrowsGameModeVisible)
        songs = songs.Where(s => s.SupportedGameModes.HasFlag(GameMode.NoArrows));

      if (this.Is90GameModeVisible)
        songs = songs.Where(s => s.SupportedGameModes.HasFlag(GameMode.NinetyDegrees));

      if (this.Is360GameModeVisible)
        songs = songs.Where(s => s.SupportedGameModes.HasFlag(GameMode.ThreeSixtyDegrees));

      this.Songs.AddRange(songs.Select(i => new UISong(i)));
    }

    this.IsSongsAvailable = this.Songs.Count > 0;
  }

  public void RefreshPlaylists() {
    var bs = this.BeatSaber;
    this.CurrentPlaylist = null;
    this.Playlists.Clear();
    if (bs != null)
      this.Playlists.AddRange(bs.Playlists.Select(i => new UIPlaylist(i)));

    this.IsPlaylistsAvailable = this.Playlists.Count > 0;
  }

}
