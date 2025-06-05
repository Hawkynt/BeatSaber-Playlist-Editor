using System.ComponentModel;
using System.Runtime.CompilerServices;
using BeatSaberAPI;

namespace BeatSaber_Playlist_Editor.ViewModel;
internal partial class UIMain : INotifyPropertyChanged {

  public event PropertyChangedEventHandler? PropertyChanged;

  protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null) => this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

  public bool IsPlaylistsAvailable {
    get => field;
    private set => this.SetProperty(this.OnPropertyChanged, ref field, value);
  }

  public bool IsRefreshAvailable {
    get => field;
    private set => this.SetProperty(this.OnPropertyChanged, ref field, value);
  }

  public bool IsCurrentPlaylistAvailable {
    get => field;
    private set => this.SetProperty(this.OnPropertyChanged, ref field, value);
  }

  public bool IsCurrentPlaylistSaveAvailable {
    get => field;
    private set => this.SetProperty(this.OnPropertyChanged, ref field, value);
  }

  public bool IsSongsAvailable {
    get => field;
    private set => this.SetProperty(this.OnPropertyChanged, ref field, value);
  }

  public string? SongFilterText {
    get => field;
    set {
      if (this.SetProperty(this.OnPropertyChanged, ref field, value))
        this.RefreshSongs();
    }
  }

  public bool IsStandardGameModeVisible {
    get => field;
    set {
      if (this.SetProperty(this.OnPropertyChanged, ref field, value))
        this.RefreshSongs();
    }
  }

  public bool IsOneSaberGameModeVisible {
    get => field;
    set {
      if (this.SetProperty(this.OnPropertyChanged, ref field, value))
        this.RefreshSongs();
    }
  }

  public bool IsNoArrowsGameModeVisible {
    get => field;
    set {
      if (this.SetProperty(this.OnPropertyChanged, ref field, value))
        this.RefreshSongs();
    }
  }

  public bool Is90GameModeVisible {
    get => field;
    set {
      if (this.SetProperty(this.OnPropertyChanged, ref field, value))
        this.RefreshSongs();
    }
  }

  public bool Is360GameModeVisible {
    get => field;
    set {
      if (this.SetProperty(this.OnPropertyChanged, ref field, value))
        this.RefreshSongs();
    }
  }

  public string CurrentPlaylistName {
    get => field;
    set {
      if (this.SetProperty(this.OnPropertyChanged, ref field, value))
        this._MarkCurrentPlaylistModified();
    }
  } = string.Empty;

  public string CurrentPlaylistAuthor {
    get => field;
    set {
      if (this.SetProperty(this.OnPropertyChanged, ref field, value))
        this._MarkCurrentPlaylistModified();
    }
  } = string.Empty;

  public string? CurrentPlaylistDescription {
    get => field;
    set {
      if (this.SetProperty(this.OnPropertyChanged, ref field, value))
        this._MarkCurrentPlaylistModified();
    }
  } = string.Empty;

  public IBeatSaberInstallation? BeatSaber {
    get => field;
    private set {
      if (!this.SetProperty(this.OnPropertyChanged, ref field, value))
        return;

      this.IsRefreshAvailable = value != null;
      this.Refresh();
    }
  }

  public UIPlaylist? CurrentPlaylist {
    get => field;
    private set {
      if (!this.SetProperty(this.OnPropertyChanged, ref field, value))
        return;

      this.RereadCurrentPlaylist();
    }
  }

  public UISong? CurrentSong {
    get => field;
    set => this.SetProperty(this.OnPropertyChanged, ref field, value);
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
    cp.Source.Description = this.CurrentPlaylistDescription;
    cp.Source.Songs.Clear();
    foreach (var entry in this.CurrentPlaylistEntries)
      cp.Source.Songs.Add(entry.Source);

    cp.Source.WriteToDisk();
    cp.TriggerAllPropertiesChanged();
    this._MarkCurrentPlaylistUnmodified();

    if (this.Playlists.ContainsNot(cp))
      this.Playlists.Add(cp);
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
    this.CurrentPlaylistDescription = cp?.Description;
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
    var currentPlaylistEntries = this.CurrentPlaylistEntries;

    foreach (var entry in entries.OrderBy(e => currentPlaylistEntries.IndexOf(e))) {
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
    var currentPlaylistEntries = this.CurrentPlaylistEntries;
    var length = currentPlaylistEntries.Count - 1;

    foreach (var entry in entries.OrderByDescending(e => currentPlaylistEntries.IndexOf(e))) {
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

  public void CreatePlaylist() {
    var beatSaber = this.BeatSaber;
    if (beatSaber == null)
      return;

    this.CurrentPlaylist = new UIPlaylist(beatSaber.Playlists.Create("New"));
  }
}
