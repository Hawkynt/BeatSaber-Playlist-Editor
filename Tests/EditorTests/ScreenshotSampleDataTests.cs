using BeatSaber_Playlist_Editor;
using BeatSaber_Playlist_Editor.ViewModel;
using NUnit.Framework;

namespace EditorTests;

public partial class Tests {

  [Test]
  public void ScreenshotSampleDataPopulatesAllVisibleAreas() {
    UIMain vm = new() { IsStandardGameModeVisible = true };
    vm.SetInstallation(ScreenshotSampleData.CreateInstallation());
    vm.SetCurrentPlaylist(vm.Playlists[0]);
    vm.CurrentSong = vm.Songs[0];

    Assert.That(vm.Playlists, Has.Count.GreaterThanOrEqualTo(3));
    Assert.That(vm.Songs, Has.Count.GreaterThanOrEqualTo(5));
    Assert.That(vm.CurrentPlaylistEntries, Has.Count.GreaterThanOrEqualTo(3));
    Assert.That(vm.CurrentPlaylistName, Is.Not.Empty);
    Assert.That(vm.CurrentPlaylistAuthor, Is.Not.Empty);
    Assert.That(vm.CurrentPlaylistDescription, Is.Not.Empty);
    Assert.That(vm.CurrentSong?.Title, Is.Not.Empty);
    Assert.That(vm.CurrentSong?.Artist, Is.Not.Empty);
  }

}
