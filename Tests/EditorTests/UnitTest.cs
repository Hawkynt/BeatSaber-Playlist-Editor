using NUnit.Framework;

namespace EditorTests;

using BeatSaber_Playlist_Editor.ViewModel;

public partial class Tests {

  private static UIMain CreateVM(out UIMain.UIPlaylistEntry a, out UIMain.UIPlaylistEntry b, out UIMain.UIPlaylistEntry c) {
    var vm = new UIMain();
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

    vm.MoveUp(new[] { b });

    CollectionAssert.AreEqual(new[] { b, a, c }, vm.CurrentPlaylistEntries);
  }

  [Test]
  public void TestOneDownOrdering() {
    var vm = CreateVM(out var a, out var b, out var c);

    vm.MoveDown(new[] { b });

    CollectionAssert.AreEqual(new[] { a, c, b }, vm.CurrentPlaylistEntries);
  }

  [Test]
  public void TestMoveToFirstOrdering() {
    var vm = CreateVM(out var a, out var b, out var c);

    vm.MoveToFront(new[] { c });

    CollectionAssert.AreEqual(new[] { c, a, b }, vm.CurrentPlaylistEntries);
  }

  [Test]
  public void TestMoveToLastOrdering() {
    var vm = CreateVM(out var a, out var b, out var c);

    vm.MoveToBack(new[] { a });

    CollectionAssert.AreEqual(new[] { b, c, a }, vm.CurrentPlaylistEntries);
  }

  [Test]
  public void TestMultiUpOrdering() {
    var vm = CreateVM(out var a, out var b, out var c);

    vm.MoveUp(new[] { c, b });

    CollectionAssert.AreEqual(new[] { b, c, a }, vm.CurrentPlaylistEntries);
  }

  [Test]
  public void TestMultiDownOrdering() {
    var vm = CreateVM(out var a, out var b, out var c);

    vm.MoveDown(new[] { b, a });

    CollectionAssert.AreEqual(new[] { c, a, b }, vm.CurrentPlaylistEntries);
  }


}
