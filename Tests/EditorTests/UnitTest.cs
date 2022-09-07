namespace EditorTests;
using BeatSaberAPI;

public partial class Tests {

  private IBeatSaberInstallation _mock;

  [SetUp]
  public void Setup() {
    this._mock = new BeatSaberInstallationMock(
      new PlaylistCollectionMock(new[] {
        new PlaylistMock(new PlaylistEntryCollectionMock(new[] {
          new PlaylistEntryMock("a"),
          new PlaylistEntryMock("b"),
          new PlaylistEntryMock("c")
        }))
      }),
      null
      );
  }

  [Test]
  public void TestOneUpOrdering() {
    // TODO:
    Assert.Pass();
  }

  [Test]
  public void TestOneDownOrdering() {
    // TODO:
    Assert.Pass();
  }

  [Test]
  public void TestMoveToFirstOrdering() {
    // TODO:
    Assert.Pass();
  }

  [Test]
  public void TestMoveToLastOrdering() {
    // TODO:
    Assert.Pass();
  }


}