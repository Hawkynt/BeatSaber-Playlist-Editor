using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using BeatSaberAPI;

namespace BeatSaber_Playlist_Editor.ViewModel;

internal partial class UIMain : INotifyPropertyChanged {

  private readonly List<UISong> _allSongs = [];

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

  private string _currentPlaylistName = string.Empty;

  public string CurrentPlaylistName {
    get => this._currentPlaylistName;
    set {
      if (this.SetProperty(this.OnPropertyChanged, ref this._currentPlaylistName, value))
        this._MarkCurrentPlaylistModified();
    }
  }

  private string _currentPlaylistAuthor = string.Empty;

  public string CurrentPlaylistAuthor {
    get => this._currentPlaylistAuthor;
    set {
      if (this.SetProperty(this.OnPropertyChanged, ref this._currentPlaylistAuthor, value))
        this._MarkCurrentPlaylistModified();
    }
  }

  private string _currentPlaylistDescription = string.Empty;

  public string CurrentPlaylistDescription {
    get => this._currentPlaylistDescription;
    set {
      if (this.SetProperty(this.OnPropertyChanged, ref this._currentPlaylistDescription, value))
        this._MarkCurrentPlaylistModified();
    }
  }

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
    => this.SetInstallation(rootDirectory == null ? null : BeatSaberInstallation.FromGameDirectory(rootDirectory));

  public void SetInstallation(IBeatSaberInstallation? beatSaber)
    => this.BeatSaber = beatSaber;

  public void SetCurrentPlaylist(UIPlaylist playlist) => this.CurrentPlaylist = playlist;

  public void Refresh() {
    this.RefreshPlaylists();
    this._ReloadSongs();
  }

  private void _ReloadSongs() {
    this._allSongs.Clear();
    if (this.BeatSaber is { } beatSaber)
      this._allSongs.AddRange(beatSaber.Songs.Select(static song => new UISong(song)));

    this.RefreshSongs();
  }

  public void RefreshSongs() {
    IEnumerable<UISong> songs = this._allSongs;
    if (this.SongFilterText.IsNotNullOrWhiteSpace()) {
      var parts = this.SongFilterText!
        .Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
      songs = songs.Where(song => parts.All(part =>
        (song.Artist?.Contains(part, StringComparison.CurrentCultureIgnoreCase) ?? false)
        || song.Title.Contains(part, StringComparison.CurrentCultureIgnoreCase)
      ));
    }

    GameMode visibleModes = 0;
    if (this.IsStandardGameModeVisible)
      visibleModes |= GameMode.Normal;
    if (this.IsOneSaberGameModeVisible)
      visibleModes |= GameMode.OneSaber;
    if (this.IsNoArrowsGameModeVisible)
      visibleModes |= GameMode.NoArrows;
    if (this.Is90GameModeVisible)
      visibleModes |= GameMode.NinetyDegrees;
    if (this.Is360GameModeVisible)
      visibleModes |= GameMode.ThreeSixtyDegrees;

    if (visibleModes != 0)
      songs = songs.Where(song => (song.Source.SupportedGameModes & visibleModes) != 0);

    this.Songs.RaiseListChangedEvents = false;
    try {
      this.Songs.Clear();
      this.Songs.AddRange(songs);
    } finally {
      this.Songs.RaiseListChangedEvents = true;
      this.Songs.ResetBindings();
    }

    this.IsSongsAvailable = this.Songs.Count > 0;
  }

  public void RefreshPlaylists() {
    var bs = this.BeatSaber;
    this.CurrentPlaylist = null;
    this.Playlists.Clear();
    if (bs != null)
      this.Playlists.AddRange(bs.Playlists.Select(static playlist => new UIPlaylist(playlist)));

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
    if (this.CurrentPlaylistEntries.Count == 0)
      return;

    this.CurrentPlaylistEntries.Clear();
    this._MarkCurrentPlaylistModified();
  }

  public void RereadCurrentPlaylist() {
    var cp = this.CurrentPlaylist;
    this.CurrentPlaylistEntries.Clear();
    if (cp != null)
      this.CurrentPlaylistEntries.AddRange(cp.Source.Songs.Select(static entry => new UIPlaylistEntry(entry)));

    this.IsCurrentPlaylistAvailable = cp != null;
    this.CurrentPlaylistAuthor = cp?.Author ?? string.Empty;
    this.CurrentPlaylistName = cp?.Name ?? string.Empty;
    this.CurrentPlaylistDescription = cp?.Description ?? string.Empty;
    this._MarkCurrentPlaylistUnmodified();
  }

  private void _MarkCurrentPlaylistModified() => this.IsCurrentPlaylistSaveAvailable = true;
  private void _MarkCurrentPlaylistUnmodified() => this.IsCurrentPlaylistSaveAvailable = false;

  public void MoveToFront(IEnumerable<UIPlaylistEntry> entries) {
    var currentPlaylistEntries = this.CurrentPlaylistEntries;
    var changed = false;

    foreach (var entry in entries.Reverse()) {
      var oldPosition = currentPlaylistEntries.IndexOf(entry);
      if (oldPosition <= 0)
        continue;

      currentPlaylistEntries.RemoveAt(oldPosition);
      currentPlaylistEntries.Insert(0, entry);
      changed = true;
    }

    if (changed)
      this._MarkCurrentPlaylistModified();
  }

  public void MoveUp(IEnumerable<UIPlaylistEntry> entries) {
    var currentPlaylistEntries = this.CurrentPlaylistEntries;
    var changed = false;

    foreach (var entry in entries.OrderBy(currentPlaylistEntries.IndexOf)) {
      var oldPosition = currentPlaylistEntries.IndexOf(entry);
      if (oldPosition <= 0)
        continue;

      currentPlaylistEntries.RemoveAt(oldPosition);
      currentPlaylistEntries.Insert(oldPosition - 1, entry);
      changed = true;
    }

    if (changed)
      this._MarkCurrentPlaylistModified();
  }

  public void Remove(IEnumerable<UIPlaylistEntry> entries) {
    var currentPlaylistEntries = this.CurrentPlaylistEntries;
    var changed = false;

    foreach (var entry in entries) {
      var oldPosition = currentPlaylistEntries.IndexOf(entry);
      if (oldPosition < 0)
        continue;

      currentPlaylistEntries.RemoveAt(oldPosition);
      changed = true;
    }

    if (changed)
      this._MarkCurrentPlaylistModified();
  }

  public void MoveDown(IEnumerable<UIPlaylistEntry> entries) {
    var currentPlaylistEntries = this.CurrentPlaylistEntries;
    var lastIndex = currentPlaylistEntries.Count - 1;
    var changed = false;

    foreach (var entry in entries.OrderByDescending(currentPlaylistEntries.IndexOf)) {
      var oldPosition = currentPlaylistEntries.IndexOf(entry);
      if (oldPosition < 0 || oldPosition >= lastIndex)
        continue;

      currentPlaylistEntries.RemoveAt(oldPosition);
      currentPlaylistEntries.Insert(oldPosition + 1, entry);
      changed = true;
    }

    if (changed)
      this._MarkCurrentPlaylistModified();
  }

  public void MoveToBack(IEnumerable<UIPlaylistEntry> entries) {
    var currentPlaylistEntries = this.CurrentPlaylistEntries;
    var lastIndex = currentPlaylistEntries.Count - 1;
    var changed = false;

    foreach (var entry in entries) {
      var oldPosition = currentPlaylistEntries.IndexOf(entry);
      if (oldPosition < 0 || oldPosition >= lastIndex)
        continue;

      currentPlaylistEntries.RemoveAt(oldPosition);
      currentPlaylistEntries.Insert(lastIndex, entry);
      changed = true;
    }

    if (changed)
      this._MarkCurrentPlaylistModified();
  }

  public void InsertSongsAt(int index, IEnumerable<UISong> songs) {
    var currentPlaylist = this.CurrentPlaylist;
    if (currentPlaylist == null)
      return;

    var currentPlaylistEntries = this.CurrentPlaylistEntries;
    var changed = false;
    foreach (var song in songs) {
      var entry = currentPlaylist.Source.CreateEntry(song.Source);
      currentPlaylistEntries.Insert(index++, new UIPlaylistEntry(entry));
      changed = true;
    }

    if (changed)
      this._MarkCurrentPlaylistModified();
  }

  public void AppendSongs(IEnumerable<UISong> songs)
    => this.InsertSongsAt(this.CurrentPlaylistEntries.Count, songs);

  [SupportedOSPlatform("windows6.1")]
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

    beatSaber.Playlists.Delete(currentPlaylist.Name);
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
