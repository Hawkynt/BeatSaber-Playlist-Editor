using System.Windows.Forms;
using BeatSaber_Playlist_Editor.ViewModel;
using static BeatSaber_Playlist_Editor.ViewModel.UIMain;

namespace BeatSaber_Playlist_Editor {
  internal partial class MainForm : Form {

    private UIMain? _viewModel;

    public MainForm() => InitializeComponent();

    public void Bind(UIMain viewModel) {
      this.bsViewModel.Clear();
      this.bsViewModel.Add(this._viewModel=viewModel);
    }

    private void tsbBeatsaberSetPath_Click(object sender, EventArgs e) {
      if (this.fbdSelectRoot.ShowDialog() == DialogResult.OK)
        this._viewModel?.SetInstallation(new DirectoryInfo(this.fbdSelectRoot.SelectedPath));
    }

    private void dgvPlaylists_SelectionChanged(object sender, EventArgs e) {
      if(((DataGridView)sender).TryGetFirstSelectedItem<UIPlaylist>(out var item) && this._viewModel!=null)
        this._viewModel.CurrentPlaylist = item;
    }

    private void tsbBeatsaberRefresh_Click(object sender, EventArgs e) {
      this._viewModel?.Refresh();
    }
  }
}