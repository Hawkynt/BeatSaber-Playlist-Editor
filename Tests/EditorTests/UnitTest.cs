using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using BeatSaberAPI;
using BeatSaber_Playlist_Editor.ViewModel;
using NUnit.Framework;

namespace EditorTests;

public partial class Tests {

  private static UIMain CreateVM(out UIMain.UIPlaylistEntry a, out UIMain.UIPlaylistEntry b, out UIMain.UIPlaylistEntry c) {
    UIMain vm = new();
    a = new UIMain.UIPlaylistEntry(new PlaylistEntryMock("a"));
    b = new UIMain.UIPlaylistEntry(new PlaylistEntryMock("b"));
    c = new UIMain.UIPlaylistEntry(new PlaylistEntryMock("c"));
    vm.CurrentPlaylistEntries.Add(a);
    vm.CurrentPlaylistEntries.Add(b);
    vm.CurrentPlaylistEntries.Add(c);
    return vm;
  }

  [Test]
  public void TestOneUpOrdering() {
    var vm = CreateVM(out var a, out var b, out var c);

    vm.MoveUp([b]);

    CollectionAssert.AreEqual(new[] { b, a, c }, vm.CurrentPlaylistEntries);
  }

  [Test]
  public void TestOneDownOrdering() {
    var vm = CreateVM(out var a, out var b, out var c);

    vm.MoveDown([b]);

    CollectionAssert.AreEqual(new[] { a, c, b }, vm.CurrentPlaylistEntries);
  }

  [Test]
  public void TestMoveToFirstOrdering() {
    var vm = CreateVM(out var a, out var b, out var c);

    vm.MoveToFront([c]);

    CollectionAssert.AreEqual(new[] { c, a, b }, vm.CurrentPlaylistEntries);
  }

  [Test]
  public void TestMoveToLastOrdering() {
    var vm = CreateVM(out var a, out var b, out var c);

    vm.MoveToBack([a]);

    CollectionAssert.AreEqual(new[] { b, c, a }, vm.CurrentPlaylistEntries);
  }

  [Test]
  public void TestMultiUpOrdering() {
    var vm = CreateVM(out var a, out var b, out var c);

    vm.MoveUp([c, b]);

    CollectionAssert.AreEqual(new[] { b, c, a }, vm.CurrentPlaylistEntries);
  }

  [Test]
  public void TestMultiDownOrdering() {
    var vm = CreateVM(out var a, out var b, out var c);

    vm.MoveDown([b, a]);

    CollectionAssert.AreEqual(new[] { c, a, b }, vm.CurrentPlaylistEntries);
  }

  [Test]
  public void ClearPlaylistMarksPlaylistModified() {
    var vm = CreateVM(out _, out _, out _);

    vm.ClearCurrentPlaylist();

    Assert.That(vm.CurrentPlaylistEntries, Is.Empty);
    Assert.That(vm.IsCurrentPlaylistSaveAvailable, Is.True);
  }

  [Test]
  public void MultipleSelectedGameModesAreCombinedWithOr() {
    UIMain vm = new() {
      IsStandardGameModeVisible = true,
      IsOneSaberGameModeVisible = true
    };
    vm.SetInstallation(new InstallationMock([
      new SongMock("Standard", "Artist", GameMode.Normal),
      new SongMock("One Saber", "Artist", GameMode.OneSaber),
      new SongMock("No Arrows", "Artist", GameMode.NoArrows)
    ]));

    Assert.That(vm.Songs, Has.Count.EqualTo(2));
    Assert.That(vm.Songs[0].Title, Is.EqualTo("Standard"));
    Assert.That(vm.Songs[1].Title, Is.EqualTo("One Saber"));
  }

  [Test]
  public void FilteringDoesNotReenumerateInstallationSongs() {
    CountingSongCollection songs = new([new SongMock("Song", "Artist", GameMode.Normal)]);
    UIMain vm = new() { IsStandardGameModeVisible = true };
    vm.SetInstallation(new InstallationMock(songs));
    var enumerationsAfterLoad = songs.EnumerationCount;

    vm.SongFilterText = "song";
    vm.SongFilterText = "artist";

    Assert.That(songs.EnumerationCount, Is.EqualTo(enumerationsAfterLoad));
  }

  [Test]
  public void MissingArtistDoesNotMatchArbitraryFilter() {
    UIMain vm = new() { IsStandardGameModeVisible = true };
    vm.SetInstallation(new InstallationMock([new SongMock("Known title", null, GameMode.Normal)]));

    vm.SongFilterText = "does-not-exist";

    Assert.That(vm.Songs, Is.Empty);
  }

  private sealed class InstallationMock(ISongCollection songs) : IBeatSaberInstallation {
    public IPlaylistCollection Playlists { get; } = new EmptyPlaylistCollection();
    public ISongCollection Songs { get; } = songs;

    public InstallationMock(IEnumerable<ISong> songs) : this(new CountingSongCollection(songs)) { }
  }

  private sealed class EmptyPlaylistCollection : IPlaylistCollection {
    public IPlaylist Create(string name) => throw new System.NotSupportedException();
    public void Delete(string name) => throw new System.NotSupportedException();
    public IEnumerator<IPlaylist> GetEnumerator() => System.Linq.Enumerable.Empty<IPlaylist>().GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
  }

  private sealed class CountingSongCollection(IEnumerable<ISong> songs) : ISongCollection {
    private readonly IEnumerable<ISong> _songs = songs;
    public int EnumerationCount { get; private set; }

    public IEnumerator<ISong> GetEnumerator() {
      ++this.EnumerationCount;
      return this._songs.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
  }

  private sealed class SongMock(string title, string? artist, GameMode modes) : ISong {
    public string Title { get; } = title;
    public string? Artist { get; } = artist;
    public string? LevelAuthor => null;
    public double BeatsPerMinute => 0;
    public string? Environment => null;
    public GameMode SupportedGameModes { get; } = modes;
    public IReadOnlyDictionary<GameMode, DifficultyMode> Difficulties { get; } = new Dictionary<GameMode, DifficultyMode>();
    public Image? Image => null;
    public string CalculateChecksum() => string.Empty;
  }

}
