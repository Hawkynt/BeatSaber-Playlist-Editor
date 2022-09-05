using BeatSaber_Playlist_Editor.ViewModel;

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
  }
}