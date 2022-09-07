using System.ComponentModel;
using System.Runtime.CompilerServices;
using BeatSaberAPI;

namespace BeatSaber_Playlist_Editor.ViewModel;
internal partial class UIMain : INotifyPropertyChanged {
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
  private UISong? _currentSong;
  private string _currentPlaylistName = string.Empty;
  private string _currentPlaylistAuthor = string.Empty;

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
    private set => this.SetProperty(this.OnPropertyChanged, ref _isCurrentPlaylistSaveAvailable, value);
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

  public string CurrentPlaylistName {
    get => _currentPlaylistName;
    set {
      if (this.SetProperty(this.OnPropertyChanged, ref _currentPlaylistName, value))
        this._MarkCurrentPlaylistModified();
    }
  }

  public string CurrentPlaylistAuthor {
    get => _currentPlaylistAuthor;
    set {
      if (this.SetProperty(this.OnPropertyChanged, ref _currentPlaylistAuthor, value))
        this._MarkCurrentPlaylistModified();
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
    private set {
      var oldValue = _currentPlaylist;
      if (!this.SetProperty(this.OnPropertyChanged, ref _currentPlaylist, value))
        return;

      this.RereadCurrentPlaylist();
    }
  }

  public UISong? CurrentSong {
    get => _currentSong;
    set => this.SetProperty(this.OnPropertyChanged, ref _currentSong, value);
  }

  public SortableBindingList<UIPlaylist> Playlists { get; } = new();
  public BindingList<UIPlaylistEntry> CurrentPlaylistEntries { get; } = new();
  public SortableBindingList<UISong> Songs { get; } = new();

  public void SetInstallation(DirectoryInfo? rootDirectory)
    => this.SetInstallation(rootDirectory == null ? null : BeatSaberInstallation.FromGameDirectory(rootDirectory))
  ;

  public void SetInstallation(IBeatSaberInstallation? beatSaber)
    => this.BeatSaber = beatSaber
  ;

  public void SetCurrentPlaylist(UIPlaylist playlist) => this.CurrentPlaylist = playlist;

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
        var parts = (this.SongFilterText ?? string.Empty).Split(" ").Select(i => i.Trim());
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

  public void SaveCurrentPlaylist() {
    var cp = this.CurrentPlaylist;
    if (cp == null)
      return;

    cp.Source.Name = this.CurrentPlaylistName;
    cp.Source.Author = this.CurrentPlaylistAuthor;
    cp.Source.Songs.Clear();
    foreach (var entry in this.CurrentPlaylistEntries)
      cp.Source.Songs.Add(entry.Source);

    cp.Source.WriteToDisk();
    cp.TriggerAllPropertiesChanged();
    this._MarkCurrentPlaylistUnmodified();
  }

  public void ClearCurrentPlaylist() {
    this.CurrentPlaylistEntries.Clear();
    this._MarkCurrentPlaylistUnmodified();
  }

  public void RereadCurrentPlaylist() {
    var cp = this.CurrentPlaylist;
    this.CurrentPlaylistEntries.Clear();
    if (cp != null)
      this.CurrentPlaylistEntries.AddRange(cp.Source.Songs.Select(i => new UIPlaylistEntry(i)));

    this.IsCurrentPlaylistAvailable = cp != null;
    this.CurrentPlaylistAuthor = cp?.Author ?? string.Empty;
    this.CurrentPlaylistName= cp?.Name??string.Empty;
    this._MarkCurrentPlaylistUnmodified();
  }

  private void _MarkCurrentPlaylistModified() => this.IsCurrentPlaylistSaveAvailable = true;
  private void _MarkCurrentPlaylistUnmodified() => this.IsCurrentPlaylistSaveAvailable = false;

  public void MoveToFront(IEnumerable<UIPlaylistEntry> entries) {
    var currentPlaylistEntries = this.CurrentPlaylistEntries;

    foreach (var entry in entries.Reverse()) {
      var oldPosition = currentPlaylistEntries.IndexOf(entry);
      if (oldPosition <= 0)
        continue;

      currentPlaylistEntries.RemoveAt(oldPosition);
      currentPlaylistEntries.Insert(0, entry);
    }

    this._MarkCurrentPlaylistModified();
  }

  public void MoveUp(IEnumerable<UIPlaylistEntry> entries) {
    // TODO: fix when moving more than one
    var currentPlaylistEntries = this.CurrentPlaylistEntries;

    foreach (var entry in entries.Reverse()) {
      var oldPosition = currentPlaylistEntries.IndexOf(entry);
      if (oldPosition <= 0)
        continue;

      currentPlaylistEntries.RemoveAt(oldPosition);
      currentPlaylistEntries.Insert(oldPosition - 1, entry);
    }

    this._MarkCurrentPlaylistModified();
  }

  public void Remove(IEnumerable<UIPlaylistEntry> entries) {
    var currentPlaylistEntries = this.CurrentPlaylistEntries;

    foreach (var entry in entries) {
      var oldPosition = currentPlaylistEntries.IndexOf(entry);
      if (oldPosition < 0)
        continue;

      currentPlaylistEntries.RemoveAt(oldPosition);
    }

    this._MarkCurrentPlaylistModified();
  }

  public void MoveDown(IEnumerable<UIPlaylistEntry> entries) {
    // TODO: fix when moving more than one
    var currentPlaylistEntries = this.CurrentPlaylistEntries;
    var length = currentPlaylistEntries.Count - 1;

    foreach (var entry in entries) {
      var oldPosition = currentPlaylistEntries.IndexOf(entry);
      if (oldPosition < 0 || oldPosition >= length)
        continue;

      currentPlaylistEntries.RemoveAt(oldPosition);
      currentPlaylistEntries.Insert(oldPosition + 1, entry);
    }

    this._MarkCurrentPlaylistModified();
  }

  public void MoveToBack(IEnumerable<UIPlaylistEntry> entries) {
    var currentPlaylistEntries = this.CurrentPlaylistEntries;
    var length = currentPlaylistEntries.Count - 1;

    foreach (var entry in entries) {
      var oldPosition = currentPlaylistEntries.IndexOf(entry);
      if (oldPosition < 0 || oldPosition >= length)
        continue;

      currentPlaylistEntries.RemoveAt(oldPosition);
      currentPlaylistEntries.Insert(length, entry);
    }

    this._MarkCurrentPlaylistModified();
  }

  public void AppendSongs(IEnumerable<UISong> songs) {
    var currentPlaylist = this.CurrentPlaylist;
    if (currentPlaylist == null)
      return;

    var currentPlaylistEntries = this.CurrentPlaylistEntries;
    foreach (var song in songs) {
      var entry = currentPlaylist.Source.CreateEntry(song.Source);
      currentPlaylistEntries.Add(new UIPlaylistEntry(entry));
    }

    this._MarkCurrentPlaylistModified();
  }

  public void SetPlaylistCover(FileInfo file) {
    var currentPlaylist = this.CurrentPlaylist;
    if (currentPlaylist == null)
      return;

    using var img = Image.FromFile(file.FullName);
    currentPlaylist.Cover = img;

    this._MarkCurrentPlaylistModified();
  }

  public bool ValidatePlaylistNameNotEmpty(string text) => text.IsNotNullOrWhiteSpace();
  
  public void DeleteCurrentPlaylist() {
    var currentPlaylist = this.CurrentPlaylist;
    if (currentPlaylist == null)
      return;

    var beatSaber = this.BeatSaber;
    if (beatSaber == null)
      return;

    var name = currentPlaylist.Name;
    beatSaber.Playlists.Delete(name);
    this.Playlists.Remove(currentPlaylist);
    this.CurrentPlaylist = null;
  }

}
