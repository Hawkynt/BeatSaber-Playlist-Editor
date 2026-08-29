using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using BeatSaberAPI;

namespace BeatSaber_Playlist_Editor;

internal static class ScreenshotSampleData {

  public static IBeatSaberInstallation CreateInstallation() {
    SampleSong[] songs = [
      new(
        "Escape Velocity",
        "Neon Vector",
        "SynthForge",
        174,
        "OriginsEnvironment",
        GameMode.Normal | GameMode.OneSaber,
        _CreateDifficulties(
          (GameMode.Normal, DifficultyMode.Hard | DifficultyMode.Expert | DifficultyMode.ExpertPlus),
          (GameMode.OneSaber, DifficultyMode.Hard | DifficultyMode.Expert)
        ),
        "0123456789ABCDEF0123456789ABCDEF01234567"
      ),
      new(
        "Clockwork Hearts",
        "Glass Circuit",
        "Mira",
        128,
        "BigMirrorEnvironment",
        GameMode.Normal | GameMode.NoArrows,
        _CreateDifficulties(
          (GameMode.Normal, DifficultyMode.Normal | DifficultyMode.Hard | DifficultyMode.Expert),
          (GameMode.NoArrows, DifficultyMode.Hard)
        ),
        "123456789ABCDEF0123456789ABCDEF012345678"
      ),
      new(
        "Starlight Run",
        "Asteria",
        "Kite",
        150,
        "KaleidoscopeEnvironment",
        GameMode.Normal | GameMode.NinetyDegrees,
        _CreateDifficulties(
          (GameMode.Normal, DifficultyMode.Hard | DifficultyMode.Expert),
          (GameMode.NinetyDegrees, DifficultyMode.Expert)
        ),
        "23456789ABCDEF0123456789ABCDEF0123456789"
      ),
      new(
        "Redline Reverie",
        "Signal Bloom",
        "MapSmith",
        196,
        "DragonsEnvironment",
        GameMode.Normal | GameMode.ThreeSixtyDegrees,
        _CreateDifficulties(
          (GameMode.Normal, DifficultyMode.Expert | DifficultyMode.ExpertPlus),
          (GameMode.ThreeSixtyDegrees, DifficultyMode.Expert)
        ),
        "3456789ABCDEF0123456789ABCDEF0123456789A"
      ),
      new(
        "Paper Satellites",
        "Quiet Current",
        "Nova",
        112,
        "LatticeEnvironment",
        GameMode.Normal,
        _CreateDifficulties((GameMode.Normal, DifficultyMode.Easy | DifficultyMode.Normal | DifficultyMode.Hard)),
        "456789ABCDEF0123456789ABCDEF0123456789AB"
      ),
      new(
        "Afterimage",
        "Low Orbit",
        "Vex",
        160,
        "PyroEnvironment",
        GameMode.Normal | GameMode.OneSaber | GameMode.NoArrows,
        _CreateDifficulties(
          (GameMode.Normal, DifficultyMode.Hard | DifficultyMode.Expert | DifficultyMode.ExpertPlus),
          (GameMode.OneSaber, DifficultyMode.Expert),
          (GameMode.NoArrows, DifficultyMode.Hard | DifficultyMode.Expert)
        ),
        "56789ABCDEF0123456789ABCDEF0123456789ABC"
      )
    ];

    SamplePlaylist[] playlists = [
      new(
        "Night Drive",
        "Playlist Editor",
        "Fast custom maps for a neon-lit session.",
        [songs[0], songs[1], songs[2], songs[3]]
      ),
      new(
        "Warmup",
        "Playlist Editor",
        "A short ramp from comfortable patterns into harder maps.",
        [songs[4], songs[1], songs[2]]
      ),
      new(
        "One Saber Favorites",
        "Playlist Editor",
        "Maps with dedicated One Saber difficulties.",
        [songs[0], songs[5]]
      )
    ];

    return new SampleInstallation(new SamplePlaylistCollection(playlists), new SampleSongCollection(songs));
  }

  private static IReadOnlyDictionary<GameMode, DifficultyMode> _CreateDifficulties(params (GameMode Mode, DifficultyMode Difficulties)[] entries) {
    Dictionary<GameMode, DifficultyMode> result = [];
    foreach (var entry in entries)
      result.Add(entry.Mode, entry.Difficulties);

    return result;
  }

  private sealed class SampleInstallation(IPlaylistCollection playlists, ISongCollection songs) : IBeatSaberInstallation {
    public IPlaylistCollection Playlists { get; } = playlists;
    public ISongCollection Songs { get; } = songs;
  }

  private sealed class SampleSong(
    string title,
    string? artist,
    string? levelAuthor,
    double beatsPerMinute,
    string? environment,
    GameMode supportedGameModes,
    IReadOnlyDictionary<GameMode, DifficultyMode> difficulties,
    string checksum
  ) : ISong {
    public string Title { get; } = title;
    public string? Artist { get; } = artist;
    public string? LevelAuthor { get; } = levelAuthor;
    public double BeatsPerMinute { get; } = beatsPerMinute;
    public string? Environment { get; } = environment;
    public GameMode SupportedGameModes { get; } = supportedGameModes;
    public IReadOnlyDictionary<GameMode, DifficultyMode> Difficulties { get; } = difficulties;
    public Image? Image => null;
    public string CalculateChecksum() => checksum;
  }

  private sealed class SampleSongCollection(IEnumerable<ISong> songs) : ISongCollection {
    private readonly List<ISong> _songs = new(songs);

    public IEnumerator<ISong> GetEnumerator() => this._songs.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
  }

  private sealed class SamplePlaylistCollection(IEnumerable<IPlaylist> playlists) : IPlaylistCollection {
    private readonly List<IPlaylist> _playlists = new(playlists);

    public IPlaylist Create(string name) {
      SamplePlaylist playlist = new(name, null, null, Array.Empty<ISong>());
      this._playlists.Add(playlist);
      return playlist;
    }

    public void Delete(string name) {
      for (var i = this._playlists.Count - 1; i >= 0; --i)
        if (string.Equals(this._playlists[i].Name, name, StringComparison.OrdinalIgnoreCase))
          this._playlists.RemoveAt(i);
    }

    public IEnumerator<IPlaylist> GetEnumerator() => this._playlists.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
  }

  private sealed class SamplePlaylist : IPlaylist {
    public string Name { get; set; }
    public string? Author { get; set; }
    public string? Description { get; set; }
    public Image? Image { get; private set; }
    public IPlaylistEntryCollection Songs { get; }

    public SamplePlaylist(string name, string? author, string? description, IEnumerable<ISong> songs) {
      this.Name = name;
      this.Author = author;
      this.Description = description;

      SamplePlaylistEntryCollection entries = new();
      foreach (var song in songs)
        entries.Add(this.CreateEntry(song));

      this.Songs = entries;
    }

    public IPlaylistEntry CreateEntry(ISong song, string? displayName = null)
      => new SamplePlaylistEntry(displayName ?? song.Title, song.CalculateChecksum());

    public void WriteToDisk() { }
    public void SetImage(Image? image) => this.Image = image;
  }

  private sealed class SamplePlaylistEntry(string name, string sha1Hash) : IPlaylistEntry {
    public string Name { get; } = name;
    public string Sha1Hash { get; } = sha1Hash;
  }

  private sealed class SamplePlaylistEntryCollection : IPlaylistEntryCollection {
    private readonly List<IPlaylistEntry> _entries = [];

    public void Add(IPlaylistEntry entry) => this._entries.Add(entry);
    public void Clear() => this._entries.Clear();
    public bool ContainsByHash(string hash) => this._entries.Exists(entry => string.Equals(entry.Sha1Hash, hash, StringComparison.OrdinalIgnoreCase));
    public bool ContainsByName(string name) => this._entries.Exists(entry => string.Equals(entry.Name, name, StringComparison.OrdinalIgnoreCase));
    public void InsertAt(int index, IPlaylistEntry entry) => this._entries.Insert(index, entry);
    public void RemoveAt(int index) => this._entries.RemoveAt(index);
    public IEnumerator<IPlaylistEntry> GetEnumerator() => this._entries.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
  }

}
