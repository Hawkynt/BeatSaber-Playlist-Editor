using BeatSaber_Playlist_Editor.ViewModel;
using static BeatSaber_Playlist_Editor.ViewModel.UIMain;

namespace BeatSaber_Playlist_Editor {
  internal partial class MainForm : Form {

    private UIMain? _viewModel;

    public MainForm() => InitializeComponent();

    public void Bind(UIMain viewModel) {
      this.bsViewModel.Clear();
      this.bsViewModel.Add(this._viewModel = viewModel);
    }

    private void tsbBeatsaberSetPath_Click(object sender, EventArgs e) {
      if (this.fbdSelectRoot.ShowDialog() == DialogResult.OK)
        this._viewModel?.SetInstallation(new DirectoryInfo(this.fbdSelectRoot.SelectedPath));
    }

    private void dgvPlaylists_SelectionChanged(object sender, EventArgs e) {
      if (((DataGridView)sender).TryGetFirstSelectedItem<UIPlaylist>(out var item) && this._viewModel != null)
        this._viewModel.CurrentPlaylist = item;
    }

    private void tsbBeatsaberRefresh_Click(object sender, EventArgs e) {
      // TODO: ask confirmation if changed
      this._viewModel?.Refresh();
    }

    private void tsbPlaylistSave_Click(object sender, EventArgs e) {
      this._viewModel?.SaveCurrentPlaylist();
    }

    private void tsbEntryFirst_Click(object sender, EventArgs e) {
      var selected = this.dgvPlaylistEntries.GetSelectedItems<UIPlaylistEntry>();
      if (selected.IsNotNullOrEmpty())
        this._viewModel?.MoveToFront(selected);
    }

    private void tsbEntryUp_Click(object sender, EventArgs e) {
      var selected = this.dgvPlaylistEntries.GetSelectedItems<UIPlaylistEntry>();
      if (selected.IsNotNullOrEmpty())
        this._viewModel?.MoveUp(selected);
    }

    private void tsbEntryRemove_Click(object sender, EventArgs e) {
      var selected = this.dgvPlaylistEntries.GetSelectedItems<UIPlaylistEntry>();
      if (selected.IsNotNullOrEmpty())
        this._viewModel?.Remove(selected);
    }

    private void tsbEntryDown_Click(object sender, EventArgs e) {
      var selected = this.dgvPlaylistEntries.GetSelectedItems<UIPlaylistEntry>();
      if (selected.IsNotNullOrEmpty())
        this._viewModel?.MoveDown(selected);
    }

    private void tsbEntryLast_Click(object sender, EventArgs e) {
      var selected = this.dgvPlaylistEntries.GetSelectedItems<UIPlaylistEntry>();
      if (selected.IsNotNullOrEmpty())
        this._viewModel?.MoveToBack(selected);
    }

    private void tsbEntryClear_Click(object sender, EventArgs e) {
      // TODO: ask confirmation if changed
      this._viewModel?.ClearCurrentPlaylist();
    }

    private void tsbPlaylistReread_Click(object sender, EventArgs e) {
      // TODO: ask confirmation if changed
      this._viewModel?.RereadCurrentPlaylist();
    }

    private void dgvSongs_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e) {

    }

    private void dgvPlaylistEntries_MouseUp(object sender, MouseEventArgs e) {

    }
  }
}