using BeatSaber_Playlist_Editor.ViewModel;
using BeatSaberAPI;
using static BeatSaber_Playlist_Editor.ViewModel.UIMain;

namespace BeatSaber_Playlist_Editor {
  internal partial class MainForm : Form {

    private UIMain? _viewModel;

    private bool _HasPlaylistChanged => this._viewModel != null && this._viewModel.IsCurrentPlaylistSaveAvailable;

    public MainForm() => InitializeComponent();

    public void Bind(UIMain viewModel) {
      this.bsViewModel.Clear();
      this.bsViewModel.Add(this._viewModel = viewModel);

      this.dgvPlaylists.EnableExtendedAttributes();
      this.dgvPlaylists.DataSource = viewModel?.Playlists;

      this.dgvPlaylistEntries.EnableExtendedAttributes();
      this.dgvPlaylistEntries.DataSource = viewModel?.CurrentPlaylistEntries;

      this.dgvSongs.EnableExtendedAttributes();
      this.dgvSongs.DataSource = viewModel?.Songs;
    }

    private void tsbBeatsaberSetPath_Click(object _, EventArgs __) {
      if (this.fbdSelectRoot.ShowDialog() != DialogResult.OK)
        return;

      try {
        this._viewModel?.SetInstallation(new DirectoryInfo(this.fbdSelectRoot.SelectedPath));
      } catch (Exception ex) {
        MessageBox.Show("Could not set BeatSaber directory.\r\nAre you sure you selected the right one?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void dgvPlaylists_SelectionChanged(object sender, EventArgs _) {
      if (((DataGridView)sender).TryGetFirstSelectedItem<UIPlaylist>(out var item))
        this._viewModel?.SetCurrentPlaylist(item);
    }

    private void tsbBeatsaberRefresh_Click(object _, EventArgs __) {
      if (_HasPlaylistChanged && MessageBox.Show("Executing this will revert all changes made to the current playlist.\r\nAre you sure?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
        return;

      this._viewModel?.Refresh();
    }

    private void tsbPlaylistSave_Click(object _, EventArgs __) {
      this._viewModel?.SaveCurrentPlaylist();
    }

    private void tsbEntryFirst_Click(object _, EventArgs __) {
      var selected = this.dgvPlaylistEntries.GetSelectedItems<UIPlaylistEntry>();
      if (selected.IsNotNullOrEmpty())
        this._viewModel?.MoveToFront(selected);
    }

    private void tsbEntryUp_Click(object _, EventArgs __) {
      var selected = this.dgvPlaylistEntries.GetSelectedItems<UIPlaylistEntry>();
      if (selected.IsNotNullOrEmpty())
        this._viewModel?.MoveUp(selected);
    }

    private void tsbEntryRemove_Click(object _, EventArgs __) {
      var selected = this.dgvPlaylistEntries.GetSelectedItems<UIPlaylistEntry>();
      if (selected.IsNotNullOrEmpty())
        this._viewModel?.Remove(selected);
    }

    private void tsbEntryDown_Click(object _, EventArgs __) {
      var selected = this.dgvPlaylistEntries.GetSelectedItems<UIPlaylistEntry>();
      if (selected.IsNotNullOrEmpty())
        this._viewModel?.MoveDown(selected);
    }

    private void tsbEntryLast_Click(object _, EventArgs __) {
      var selected = this.dgvPlaylistEntries.GetSelectedItems<UIPlaylistEntry>();
      if (selected.IsNotNullOrEmpty())
        this._viewModel?.MoveToBack(selected);
    }

    private void tsbEntryClear_Click(object _, EventArgs __) {
      if (_HasPlaylistChanged && MessageBox.Show("Executing this will revert all changes made to the current playlist.\r\nAre you sure?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
        return;

      this._viewModel?.ClearCurrentPlaylist();
    }

    private void tsbPlaylistReread_Click(object _, EventArgs __) {
      if (_HasPlaylistChanged && MessageBox.Show("Executing this will revert all changes made to the current playlist.\r\nAre you sure?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
        return;

      this._viewModel?.RereadCurrentPlaylist();
    }

    private void dgvSongs_CellMouseDown(object _, DataGridViewCellMouseEventArgs e) {
      if (e.ColumnIndex < 0 || e.RowIndex < 0)
        return;

      // if dragged row not yet selected - select it
      this.dgvSongs.Rows[e.RowIndex].Selected = true;


      var selected = this.dgvSongs.GetSelectedItems<UISong>().ToArray();
      this.dgvSongs.DoDragDrop(selected, DragDropEffects.Copy);
    }

    private void dgvPlaylistEntries_DragEnter(object _, DragEventArgs e) {
      if (e.Data?.GetDataPresent(typeof(UISong[])) ?? false)
        e.Effect = DragDropEffects.Copy;
    }

    private void dgvPlaylistEntries_DragDrop(object _, DragEventArgs e) {
      if (e.Data?.GetData(typeof(UISong[])) is not UISong[] songs) {
        e.Effect = DragDropEffects.None;
        return;
      }

      this._viewModel?.AppendSongs(songs);
      // TODO: would be nice to know where drop occured and insert songs there if possible
    }

    private void pbPlaylistCover_Click(object _, EventArgs __) {
      if (this.ofdSelectImage.ShowDialog() != DialogResult.OK)
        return;

      try {
        this._viewModel?.SetPlaylistCover(new FileInfo(this.ofdSelectImage.FileName));
      } catch (Exception ex) {
        MessageBox.Show("Could not set cover image.\r\nAre you sure you selected the right thing?", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void dgvSongs_SelectionChanged(object _, EventArgs __) {
      if (this._viewModel == null)
        return;

      if (this.dgvSongs.TryGetFirstSelectedItem<UISong>(out var song))
        this._viewModel.CurrentSong = song;
    }

    private void tbPlaylistName_Validating(object sender, System.ComponentModel.CancelEventArgs e) {
      var tb = (TextBox)sender;
      if (this._viewModel?.ValidatePlaylistNameNotEmpty(tb.Text) ?? false)
        return;

      MessageBox.Show("Playlist name must not be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      e.Cancel = true;
    }

    private void tsbDeletePlaylist_Click(object _, EventArgs __) {
      if (MessageBox.Show($"This will delete the currently selected playlist '{this._viewModel?.CurrentPlaylist?.Name}'.\r\nAre you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        this._viewModel?.DeleteCurrentPlaylist();
    }

    private void tsbCreatePlaylist_Click(object _, EventArgs __) {
      this._viewModel?.CreatePlaylist();
      this.tbPlaylistName.Focus();
    }

  }
}