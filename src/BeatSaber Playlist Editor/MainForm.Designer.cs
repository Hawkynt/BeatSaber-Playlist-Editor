namespace BeatSaber_Playlist_Editor {
  partial class MainForm : Form {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.components = new System.ComponentModel.Container();
      System.Windows.Forms.StatusStrip ssStatus;
      System.Windows.Forms.SplitContainer splitContainer1;
      System.Windows.Forms.ToolStrip tsBeatsaber;
      System.Windows.Forms.BindableToolStripButton tsbBeatsaberSetPath;
      System.Windows.Forms.BindableToolStripButton tsbCreatePlaylist;
      System.Windows.Forms.BindableToolStripButton tsbBeatsaberRefresh;
      System.Windows.Forms.BindableToolStripButton tsbDeletePlaylist;
      System.Windows.Forms.SplitContainer splitContainer2;
      System.Windows.Forms.SplitContainer splitContainer4;
      System.Windows.Forms.ToolStrip tsPlaylist;
      System.Windows.Forms.BindableToolStripButton tsbPlaylistSave;
      System.Windows.Forms.BindableToolStripButton tsbEntryFirst;
      System.Windows.Forms.BindableToolStripButton tsbEntryUp;
      System.Windows.Forms.BindableToolStripButton tsbEntryRemove;
      System.Windows.Forms.BindableToolStripButton tsbEntryDown;
      System.Windows.Forms.BindableToolStripButton tsbEntryLast;
      System.Windows.Forms.BindableToolStripButton tsbEntryClear;
      System.Windows.Forms.BindableToolStripButton tsbPlaylistReread;
      System.Windows.Forms.GroupBox gbPlaylistProperties;
      System.Windows.Forms.TableLayoutPanel tlpPlaylistProperties;
      System.Windows.Forms.Label lPlaylistCoverDetails;
      System.Windows.Forms.PictureBox pbPlaylistCover;
      System.Windows.Forms.Label lPlaylistName;
      System.Windows.Forms.Label lPlaylistAuthor;
      System.Windows.Forms.TextBox tbPlaylistAuthor;
      System.Windows.Forms.SplitContainer splitContainer3;
      System.Windows.Forms.ToolStrip tsSongs;
      System.Windows.Forms.ToolStripLabel tslFilter;
      System.Windows.Forms.BindableToolStripSpringTextBox tstbSongFilter;
      System.Windows.Forms.BindableToolStripButton tsbModeStandard;
      System.Windows.Forms.BindableToolStripButton tsbModeOneSaber;
      System.Windows.Forms.BindableToolStripButton tsbModeNoArrows;
      System.Windows.Forms.BindableToolStripButton tsbMode90;
      System.Windows.Forms.BindableToolStripButton tsbMode360;
      System.Windows.Forms.GroupBox gbSongProperties;
      System.Windows.Forms.TableLayoutPanel tlpSongProperties;
      System.Windows.Forms.Label lSongCoverDetails;
      System.Windows.Forms.PictureBox pbSongCover;
      System.Windows.Forms.Label lArtist;
      System.Windows.Forms.Label lArtistData;
      System.Windows.Forms.Label lTitleData;
      System.Windows.Forms.Label lLevelAuthorData;
      System.Windows.Forms.Label lLevelAuthor;
      System.Windows.Forms.Label lTitle;
      System.Windows.Forms.Label lEnvironment;
      System.Windows.Forms.Label lBeatsPerMinute;
      System.Windows.Forms.Label lEnvironmentData;
      System.Windows.Forms.Label lBeatsPerMinuteData;
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.dgvPlaylists = new System.Windows.Forms.DataGridView();
      this.bsViewModel = new System.Windows.Forms.BindingSource(this.components);
      this.dgvPlaylistEntries = new System.Windows.Forms.DataGridView();
      this.tbPlaylistName = new System.Windows.Forms.TextBox();
      this.dgvSongs = new System.Windows.Forms.DataGridView();
      this.fbdSelectRoot = new System.Windows.Forms.FolderBrowserDialog();
      this.ofdSelectImage = new System.Windows.Forms.OpenFileDialog();
      ssStatus = new System.Windows.Forms.StatusStrip();
      splitContainer1 = new System.Windows.Forms.SplitContainer();
      tsBeatsaber = new System.Windows.Forms.ToolStrip();
      tsbBeatsaberSetPath = new System.Windows.Forms.BindableToolStripButton();
      tsbCreatePlaylist = new System.Windows.Forms.BindableToolStripButton();
      tsbBeatsaberRefresh = new System.Windows.Forms.BindableToolStripButton();
      tsbDeletePlaylist = new System.Windows.Forms.BindableToolStripButton();
      splitContainer2 = new System.Windows.Forms.SplitContainer();
      splitContainer4 = new System.Windows.Forms.SplitContainer();
      tsPlaylist = new System.Windows.Forms.ToolStrip();
      tsbPlaylistSave = new System.Windows.Forms.BindableToolStripButton();
      tsbEntryFirst = new System.Windows.Forms.BindableToolStripButton();
      tsbEntryUp = new System.Windows.Forms.BindableToolStripButton();
      tsbEntryRemove = new System.Windows.Forms.BindableToolStripButton();
      tsbEntryDown = new System.Windows.Forms.BindableToolStripButton();
      tsbEntryLast = new System.Windows.Forms.BindableToolStripButton();
      tsbEntryClear = new System.Windows.Forms.BindableToolStripButton();
      tsbPlaylistReread = new System.Windows.Forms.BindableToolStripButton();
      gbPlaylistProperties = new System.Windows.Forms.GroupBox();
      tlpPlaylistProperties = new System.Windows.Forms.TableLayoutPanel();
      lPlaylistCoverDetails = new System.Windows.Forms.Label();
      pbPlaylistCover = new System.Windows.Forms.PictureBox();
      lPlaylistName = new System.Windows.Forms.Label();
      lPlaylistAuthor = new System.Windows.Forms.Label();
      tbPlaylistAuthor = new System.Windows.Forms.TextBox();
      splitContainer3 = new System.Windows.Forms.SplitContainer();
      tsSongs = new System.Windows.Forms.ToolStrip();
      tslFilter = new System.Windows.Forms.ToolStripLabel();
      tstbSongFilter = new System.Windows.Forms.BindableToolStripSpringTextBox();
      tsbModeStandard = new System.Windows.Forms.BindableToolStripButton();
      tsbModeOneSaber = new System.Windows.Forms.BindableToolStripButton();
      tsbModeNoArrows = new System.Windows.Forms.BindableToolStripButton();
      tsbMode90 = new System.Windows.Forms.BindableToolStripButton();
      tsbMode360 = new System.Windows.Forms.BindableToolStripButton();
      gbSongProperties = new System.Windows.Forms.GroupBox();
      tlpSongProperties = new System.Windows.Forms.TableLayoutPanel();
      lSongCoverDetails = new System.Windows.Forms.Label();
      pbSongCover = new System.Windows.Forms.PictureBox();
      lArtist = new System.Windows.Forms.Label();
      lArtistData = new System.Windows.Forms.Label();
      lTitleData = new System.Windows.Forms.Label();
      lLevelAuthorData = new System.Windows.Forms.Label();
      lLevelAuthor = new System.Windows.Forms.Label();
      lTitle = new System.Windows.Forms.Label();
      lEnvironment = new System.Windows.Forms.Label();
      lBeatsPerMinute = new System.Windows.Forms.Label();
      lEnvironmentData = new System.Windows.Forms.Label();
      lBeatsPerMinuteData = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(splitContainer1)).BeginInit();
      splitContainer1.Panel1.SuspendLayout();
      splitContainer1.Panel2.SuspendLayout();
      splitContainer1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgvPlaylists)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.bsViewModel)).BeginInit();
      tsBeatsaber.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(splitContainer2)).BeginInit();
      splitContainer2.Panel1.SuspendLayout();
      splitContainer2.Panel2.SuspendLayout();
      splitContainer2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(splitContainer4)).BeginInit();
      splitContainer4.Panel1.SuspendLayout();
      splitContainer4.Panel2.SuspendLayout();
      splitContainer4.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgvPlaylistEntries)).BeginInit();
      tsPlaylist.SuspendLayout();
      gbPlaylistProperties.SuspendLayout();
      tlpPlaylistProperties.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(pbPlaylistCover)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(splitContainer3)).BeginInit();
      splitContainer3.Panel1.SuspendLayout();
      splitContainer3.Panel2.SuspendLayout();
      splitContainer3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgvSongs)).BeginInit();
      tsSongs.SuspendLayout();
      gbSongProperties.SuspendLayout();
      tlpSongProperties.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(pbSongCover)).BeginInit();
      this.SuspendLayout();
      // 
      // ssStatus
      // 
      ssStatus.Location = new System.Drawing.Point(0, 428);
      ssStatus.Name = "ssStatus";
      ssStatus.Size = new System.Drawing.Size(800, 22);
      ssStatus.TabIndex = 0;
      ssStatus.Text = "statusStrip1";
      // 
      // splitContainer1
      // 
      splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      splitContainer1.Location = new System.Drawing.Point(0, 0);
      splitContainer1.Name = "splitContainer1";
      // 
      // splitContainer1.Panel1
      // 
      splitContainer1.Panel1.Controls.Add(this.dgvPlaylists);
      splitContainer1.Panel1.Controls.Add(tsBeatsaber);
      // 
      // splitContainer1.Panel2
      // 
      splitContainer1.Panel2.Controls.Add(splitContainer2);
      splitContainer1.Size = new System.Drawing.Size(800, 428);
      splitContainer1.SplitterDistance = 266;
      splitContainer1.TabIndex = 1;
      // 
      // dgvPlaylists
      // 
      this.dgvPlaylists.AllowUserToAddRows = false;
      this.dgvPlaylists.AllowUserToDeleteRows = false;
      this.dgvPlaylists.AllowUserToOrderColumns = true;
      this.dgvPlaylists.AllowUserToResizeRows = false;
      this.dgvPlaylists.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.dgvPlaylists.BackgroundColor = System.Drawing.SystemColors.Window;
      this.dgvPlaylists.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.dgvPlaylists.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvPlaylists.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.bsViewModel, "IsPlaylistsAvailable", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.dgvPlaylists.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dgvPlaylists.Location = new System.Drawing.Point(0, 25);
      this.dgvPlaylists.MultiSelect = false;
      this.dgvPlaylists.Name = "dgvPlaylists";
      this.dgvPlaylists.ReadOnly = true;
      this.dgvPlaylists.RowHeadersVisible = false;
      this.dgvPlaylists.RowTemplate.Height = 25;
      this.dgvPlaylists.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dgvPlaylists.Size = new System.Drawing.Size(266, 403);
      this.dgvPlaylists.TabIndex = 1;
      this.dgvPlaylists.SelectionChanged += new System.EventHandler(this.dgvPlaylists_SelectionChanged);
      // 
      // bsViewModel
      // 
      this.bsViewModel.AllowNew = false;
      this.bsViewModel.DataSource = typeof(BeatSaber_Playlist_Editor.ViewModel.UIMain);
      // 
      // tsBeatsaber
      // 
      tsBeatsaber.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
      tsBeatsaber.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            tsbBeatsaberSetPath,
            tsbCreatePlaylist,
            tsbBeatsaberRefresh,
            tsbDeletePlaylist});
      tsBeatsaber.Location = new System.Drawing.Point(0, 0);
      tsBeatsaber.Name = "tsBeatsaber";
      tsBeatsaber.Size = new System.Drawing.Size(266, 25);
      tsBeatsaber.TabIndex = 0;
      tsBeatsaber.Text = "Beatsaber";
      // 
      // tsbBeatsaberSetPath
      // 
      tsbBeatsaberSetPath.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      tsbBeatsaberSetPath.Image = global::BeatSaber_Playlist_Editor.Properties.Resources._20x20_BeatSaber;
      tsbBeatsaberSetPath.ImageTransparentColor = System.Drawing.Color.Magenta;
      tsbBeatsaberSetPath.Name = "tsbBeatsaberSetPath";
      tsbBeatsaberSetPath.Size = new System.Drawing.Size(23, 22);
      tsbBeatsaberSetPath.Text = "Select BeatSaber Installation";
      tsbBeatsaberSetPath.Click += new System.EventHandler(this.tsbBeatsaberSetPath_Click);
      // 
      // tsbCreatePlaylist
      // 
      tsbCreatePlaylist.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.bsViewModel, "IsPlaylistsAvailable", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      tsbCreatePlaylist.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      tsbCreatePlaylist.Image = global::BeatSaber_Playlist_Editor.Properties.Resources._16x16_New;
      tsbCreatePlaylist.ImageTransparentColor = System.Drawing.Color.Magenta;
      tsbCreatePlaylist.Name = "tsbCreatePlaylist";
      tsbCreatePlaylist.Size = new System.Drawing.Size(23, 22);
      tsbCreatePlaylist.Text = "Create playlist";
      tsbCreatePlaylist.Click += new System.EventHandler(this.tsbCreatePlaylist_Click);
      // 
      // tsbBeatsaberRefresh
      // 
      tsbBeatsaberRefresh.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.bsViewModel, "IsRefreshAvailable", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      tsbBeatsaberRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      tsbBeatsaberRefresh.Image = global::BeatSaber_Playlist_Editor.Properties.Resources._16x16_Refresh;
      tsbBeatsaberRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
      tsbBeatsaberRefresh.Name = "tsbBeatsaberRefresh";
      tsbBeatsaberRefresh.Size = new System.Drawing.Size(23, 22);
      tsbBeatsaberRefresh.Text = "Refresh";
      tsbBeatsaberRefresh.Click += new System.EventHandler(this.tsbBeatsaberRefresh_Click);
      // 
      // tsbDeletePlaylist
      // 
      tsbDeletePlaylist.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.bsViewModel, "IsCurrentPlaylistAvailable", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      tsbDeletePlaylist.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      tsbDeletePlaylist.Image = global::BeatSaber_Playlist_Editor.Properties.Resources._16x16_Trash;
      tsbDeletePlaylist.ImageTransparentColor = System.Drawing.Color.Magenta;
      tsbDeletePlaylist.Name = "tsbDeletePlaylist";
      tsbDeletePlaylist.Size = new System.Drawing.Size(23, 22);
      tsbDeletePlaylist.Text = "Delete Playlist";
      tsbDeletePlaylist.Click += new System.EventHandler(this.tsbDeletePlaylist_Click);
      // 
      // splitContainer2
      // 
      splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
      splitContainer2.Location = new System.Drawing.Point(0, 0);
      splitContainer2.Name = "splitContainer2";
      // 
      // splitContainer2.Panel1
      // 
      splitContainer2.Panel1.Controls.Add(splitContainer4);
      // 
      // splitContainer2.Panel2
      // 
      splitContainer2.Panel2.Controls.Add(splitContainer3);
      splitContainer2.Size = new System.Drawing.Size(530, 428);
      splitContainer2.SplitterDistance = 239;
      splitContainer2.TabIndex = 0;
      // 
      // splitContainer4
      // 
      splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
      splitContainer4.Location = new System.Drawing.Point(0, 0);
      splitContainer4.Name = "splitContainer4";
      splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainer4.Panel1
      // 
      splitContainer4.Panel1.Controls.Add(this.dgvPlaylistEntries);
      splitContainer4.Panel1.Controls.Add(tsPlaylist);
      // 
      // splitContainer4.Panel2
      // 
      splitContainer4.Panel2.Controls.Add(gbPlaylistProperties);
      splitContainer4.Size = new System.Drawing.Size(239, 428);
      splitContainer4.SplitterDistance = 225;
      splitContainer4.TabIndex = 0;
      // 
      // dgvPlaylistEntries
      // 
      this.dgvPlaylistEntries.AllowDrop = true;
      this.dgvPlaylistEntries.AllowUserToAddRows = false;
      this.dgvPlaylistEntries.AllowUserToDeleteRows = false;
      this.dgvPlaylistEntries.AllowUserToResizeRows = false;
      this.dgvPlaylistEntries.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.dgvPlaylistEntries.BackgroundColor = System.Drawing.SystemColors.Window;
      this.dgvPlaylistEntries.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.dgvPlaylistEntries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvPlaylistEntries.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.bsViewModel, "IsCurrentPlaylistAvailable", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.dgvPlaylistEntries.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dgvPlaylistEntries.Location = new System.Drawing.Point(0, 25);
      this.dgvPlaylistEntries.Name = "dgvPlaylistEntries";
      this.dgvPlaylistEntries.ReadOnly = true;
      this.dgvPlaylistEntries.RowHeadersVisible = false;
      this.dgvPlaylistEntries.RowTemplate.Height = 25;
      this.dgvPlaylistEntries.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dgvPlaylistEntries.Size = new System.Drawing.Size(239, 200);
      this.dgvPlaylistEntries.TabIndex = 1;
      this.dgvPlaylistEntries.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgvPlaylistEntries_DragDrop);
      this.dgvPlaylistEntries.DragEnter += new System.Windows.Forms.DragEventHandler(this.dgvPlaylistEntries_DragEnter);
      // 
      // tsPlaylist
      // 
      tsPlaylist.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.bsViewModel, "IsCurrentPlaylistAvailable", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      tsPlaylist.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
      tsPlaylist.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            tsbPlaylistSave,
            tsbEntryFirst,
            tsbEntryUp,
            tsbEntryRemove,
            tsbEntryDown,
            tsbEntryLast,
            tsbEntryClear,
            tsbPlaylistReread});
      tsPlaylist.Location = new System.Drawing.Point(0, 0);
      tsPlaylist.Name = "tsPlaylist";
      tsPlaylist.Size = new System.Drawing.Size(239, 25);
      tsPlaylist.TabIndex = 0;
      tsPlaylist.Text = "Playlist";
      // 
      // tsbPlaylistSave
      // 
      tsbPlaylistSave.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.bsViewModel, "IsCurrentPlaylistSaveAvailable", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      tsbPlaylistSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      tsbPlaylistSave.Image = global::BeatSaber_Playlist_Editor.Properties.Resources._16x16_Save;
      tsbPlaylistSave.ImageTransparentColor = System.Drawing.Color.Magenta;
      tsbPlaylistSave.Name = "tsbPlaylistSave";
      tsbPlaylistSave.Size = new System.Drawing.Size(23, 22);
      tsbPlaylistSave.Text = "Save";
      tsbPlaylistSave.Click += new System.EventHandler(this.tsbPlaylistSave_Click);
      // 
      // tsbEntryFirst
      // 
      tsbEntryFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      tsbEntryFirst.Image = global::BeatSaber_Playlist_Editor.Properties.Resources._20x20_First;
      tsbEntryFirst.ImageTransparentColor = System.Drawing.Color.Magenta;
      tsbEntryFirst.Name = "tsbEntryFirst";
      tsbEntryFirst.Size = new System.Drawing.Size(23, 22);
      tsbEntryFirst.Text = "First";
      tsbEntryFirst.Click += new System.EventHandler(this.tsbEntryFirst_Click);
      // 
      // tsbEntryUp
      // 
      tsbEntryUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      tsbEntryUp.Image = global::BeatSaber_Playlist_Editor.Properties.Resources._20x20_Up;
      tsbEntryUp.ImageTransparentColor = System.Drawing.Color.Magenta;
      tsbEntryUp.Name = "tsbEntryUp";
      tsbEntryUp.Size = new System.Drawing.Size(23, 22);
      tsbEntryUp.Text = "Up";
      tsbEntryUp.Click += new System.EventHandler(this.tsbEntryUp_Click);
      // 
      // tsbEntryRemove
      // 
      tsbEntryRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      tsbEntryRemove.Image = global::BeatSaber_Playlist_Editor.Properties.Resources._20x20_Remove;
      tsbEntryRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
      tsbEntryRemove.Name = "tsbEntryRemove";
      tsbEntryRemove.Size = new System.Drawing.Size(23, 22);
      tsbEntryRemove.Text = "Remove";
      tsbEntryRemove.Click += new System.EventHandler(this.tsbEntryRemove_Click);
      // 
      // tsbEntryDown
      // 
      tsbEntryDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      tsbEntryDown.Image = global::BeatSaber_Playlist_Editor.Properties.Resources._20x20_Down;
      tsbEntryDown.ImageTransparentColor = System.Drawing.Color.Magenta;
      tsbEntryDown.Name = "tsbEntryDown";
      tsbEntryDown.Size = new System.Drawing.Size(23, 22);
      tsbEntryDown.Text = "Down";
      tsbEntryDown.Click += new System.EventHandler(this.tsbEntryDown_Click);
      // 
      // tsbEntryLast
      // 
      tsbEntryLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      tsbEntryLast.Image = global::BeatSaber_Playlist_Editor.Properties.Resources._20x20_Last;
      tsbEntryLast.ImageTransparentColor = System.Drawing.Color.Magenta;
      tsbEntryLast.Name = "tsbEntryLast";
      tsbEntryLast.Size = new System.Drawing.Size(23, 22);
      tsbEntryLast.Text = "Last";
      tsbEntryLast.Click += new System.EventHandler(this.tsbEntryLast_Click);
      // 
      // tsbEntryClear
      // 
      tsbEntryClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      tsbEntryClear.Image = global::BeatSaber_Playlist_Editor.Properties.Resources._16x16_Clear;
      tsbEntryClear.ImageTransparentColor = System.Drawing.Color.Magenta;
      tsbEntryClear.Name = "tsbEntryClear";
      tsbEntryClear.Size = new System.Drawing.Size(23, 22);
      tsbEntryClear.Text = "Clear";
      tsbEntryClear.Click += new System.EventHandler(this.tsbEntryClear_Click);
      // 
      // tsbPlaylistReread
      // 
      tsbPlaylistReread.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      tsbPlaylistReread.Image = global::BeatSaber_Playlist_Editor.Properties.Resources._24x24_Reread;
      tsbPlaylistReread.ImageTransparentColor = System.Drawing.Color.Magenta;
      tsbPlaylistReread.Name = "tsbPlaylistReread";
      tsbPlaylistReread.Size = new System.Drawing.Size(23, 22);
      tsbPlaylistReread.Text = "Re-read";
      tsbPlaylistReread.Click += new System.EventHandler(this.tsbPlaylistReread_Click);
      // 
      // gbPlaylistProperties
      // 
      gbPlaylistProperties.Controls.Add(tlpPlaylistProperties);
      gbPlaylistProperties.Dock = System.Windows.Forms.DockStyle.Fill;
      gbPlaylistProperties.Location = new System.Drawing.Point(0, 0);
      gbPlaylistProperties.Name = "gbPlaylistProperties";
      gbPlaylistProperties.Size = new System.Drawing.Size(239, 199);
      gbPlaylistProperties.TabIndex = 0;
      gbPlaylistProperties.TabStop = false;
      gbPlaylistProperties.Text = "Playlist properties";
      // 
      // tlpPlaylistProperties
      // 
      tlpPlaylistProperties.ColumnCount = 2;
      tlpPlaylistProperties.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tlpPlaylistProperties.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tlpPlaylistProperties.Controls.Add(lPlaylistCoverDetails, 0, 1);
      tlpPlaylistProperties.Controls.Add(pbPlaylistCover, 0, 0);
      tlpPlaylistProperties.Controls.Add(lPlaylistName, 0, 2);
      tlpPlaylistProperties.Controls.Add(lPlaylistAuthor, 0, 3);
      tlpPlaylistProperties.Controls.Add(this.tbPlaylistName, 1, 2);
      tlpPlaylistProperties.Controls.Add(tbPlaylistAuthor, 1, 3);
      tlpPlaylistProperties.Dock = System.Windows.Forms.DockStyle.Fill;
      tlpPlaylistProperties.Location = new System.Drawing.Point(3, 19);
      tlpPlaylistProperties.Name = "tlpPlaylistProperties";
      tlpPlaylistProperties.RowCount = 5;
      tlpPlaylistProperties.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tlpPlaylistProperties.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tlpPlaylistProperties.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tlpPlaylistProperties.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tlpPlaylistProperties.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      tlpPlaylistProperties.Size = new System.Drawing.Size(233, 177);
      tlpPlaylistProperties.TabIndex = 0;
      // 
      // lPlaylistCoverDetails
      // 
      lPlaylistCoverDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
      lPlaylistCoverDetails.AutoSize = true;
      tlpPlaylistProperties.SetColumnSpan(lPlaylistCoverDetails, 2);
      lPlaylistCoverDetails.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsViewModel, "CurrentPlaylist.CoverDetails", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      lPlaylistCoverDetails.Location = new System.Drawing.Point(3, 84);
      lPlaylistCoverDetails.Name = "lPlaylistCoverDetails";
      lPlaylistCoverDetails.Size = new System.Drawing.Size(227, 15);
      lPlaylistCoverDetails.TabIndex = 0;
      lPlaylistCoverDetails.Text = "100 x 100";
      lPlaylistCoverDetails.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // pbPlaylistCover
      // 
      tlpPlaylistProperties.SetColumnSpan(pbPlaylistCover, 2);
      pbPlaylistCover.DataBindings.Add(new System.Windows.Forms.Binding("Image", this.bsViewModel, "CurrentPlaylist.Cover", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      pbPlaylistCover.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.bsViewModel, "IsCurrentPlaylistAvailable", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      pbPlaylistCover.Dock = System.Windows.Forms.DockStyle.Fill;
      pbPlaylistCover.ErrorImage = global::BeatSaber_Playlist_Editor.Properties.Resources.NoPictureAvailable;
      pbPlaylistCover.Image = global::BeatSaber_Playlist_Editor.Properties.Resources.NoPictureAvailable;
      pbPlaylistCover.InitialImage = global::BeatSaber_Playlist_Editor.Properties.Resources.NoPictureAvailable;
      pbPlaylistCover.Location = new System.Drawing.Point(3, 3);
      pbPlaylistCover.Name = "pbPlaylistCover";
      pbPlaylistCover.Size = new System.Drawing.Size(227, 78);
      pbPlaylistCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      pbPlaylistCover.TabIndex = 1;
      pbPlaylistCover.TabStop = false;
      pbPlaylistCover.Click += new System.EventHandler(this.pbPlaylistCover_Click);
      // 
      // lPlaylistName
      // 
      lPlaylistName.Anchor = System.Windows.Forms.AnchorStyles.Left;
      lPlaylistName.AutoSize = true;
      lPlaylistName.Location = new System.Drawing.Point(3, 106);
      lPlaylistName.Name = "lPlaylistName";
      lPlaylistName.Size = new System.Drawing.Size(39, 15);
      lPlaylistName.TabIndex = 2;
      lPlaylistName.Text = "Name";
      // 
      // lPlaylistAuthor
      // 
      lPlaylistAuthor.Anchor = System.Windows.Forms.AnchorStyles.Left;
      lPlaylistAuthor.AutoSize = true;
      lPlaylistAuthor.Location = new System.Drawing.Point(3, 135);
      lPlaylistAuthor.Name = "lPlaylistAuthor";
      lPlaylistAuthor.Size = new System.Drawing.Size(44, 15);
      lPlaylistAuthor.TabIndex = 2;
      lPlaylistAuthor.Text = "Author";
      // 
      // tbPlaylistName
      // 
      this.tbPlaylistName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsViewModel, "CurrentPlaylistName", true));
      this.tbPlaylistName.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.bsViewModel, "IsCurrentPlaylistAvailable", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.tbPlaylistName.Dock = System.Windows.Forms.DockStyle.Top;
      this.tbPlaylistName.Location = new System.Drawing.Point(53, 102);
      this.tbPlaylistName.Name = "tbPlaylistName";
      this.tbPlaylistName.Size = new System.Drawing.Size(177, 23);
      this.tbPlaylistName.TabIndex = 3;
      this.tbPlaylistName.Validating += new System.ComponentModel.CancelEventHandler(this.tbPlaylistName_Validating);
      // 
      // tbPlaylistAuthor
      // 
      tbPlaylistAuthor.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsViewModel, "CurrentPlaylistAuthor", true));
      tbPlaylistAuthor.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.bsViewModel, "IsCurrentPlaylistAvailable", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      tbPlaylistAuthor.Dock = System.Windows.Forms.DockStyle.Top;
      tbPlaylistAuthor.Location = new System.Drawing.Point(53, 131);
      tbPlaylistAuthor.Name = "tbPlaylistAuthor";
      tbPlaylistAuthor.Size = new System.Drawing.Size(177, 23);
      tbPlaylistAuthor.TabIndex = 4;
      // 
      // splitContainer3
      // 
      splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
      splitContainer3.Location = new System.Drawing.Point(0, 0);
      splitContainer3.Name = "splitContainer3";
      splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainer3.Panel1
      // 
      splitContainer3.Panel1.Controls.Add(this.dgvSongs);
      splitContainer3.Panel1.Controls.Add(tsSongs);
      // 
      // splitContainer3.Panel2
      // 
      splitContainer3.Panel2.Controls.Add(gbSongProperties);
      splitContainer3.Size = new System.Drawing.Size(287, 428);
      splitContainer3.SplitterDistance = 223;
      splitContainer3.TabIndex = 0;
      // 
      // dgvSongs
      // 
      this.dgvSongs.AllowUserToAddRows = false;
      this.dgvSongs.AllowUserToDeleteRows = false;
      this.dgvSongs.AllowUserToResizeRows = false;
      this.dgvSongs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.dgvSongs.BackgroundColor = System.Drawing.SystemColors.Window;
      this.dgvSongs.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.dgvSongs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvSongs.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.bsViewModel, "IsSongsAvailable", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.dgvSongs.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dgvSongs.Location = new System.Drawing.Point(0, 25);
      this.dgvSongs.Name = "dgvSongs";
      this.dgvSongs.ReadOnly = true;
      this.dgvSongs.RowHeadersVisible = false;
      this.dgvSongs.RowTemplate.Height = 25;
      this.dgvSongs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dgvSongs.Size = new System.Drawing.Size(287, 198);
      this.dgvSongs.TabIndex = 1;
      this.dgvSongs.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvSongs_CellMouseDown);
      this.dgvSongs.SelectionChanged += new System.EventHandler(this.dgvSongs_SelectionChanged);
      // 
      // tsSongs
      // 
      tsSongs.CanOverflow = false;
      tsSongs.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.bsViewModel, "IsSongsAvailable", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      tsSongs.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
      tsSongs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            tslFilter,
            tstbSongFilter,
            tsbModeStandard,
            tsbModeOneSaber,
            tsbModeNoArrows,
            tsbMode90,
            tsbMode360});
      tsSongs.Location = new System.Drawing.Point(0, 0);
      tsSongs.Name = "tsSongs";
      tsSongs.Size = new System.Drawing.Size(287, 25);
      tsSongs.TabIndex = 0;
      tsSongs.Text = "Songs";
      // 
      // tslFilter
      // 
      tslFilter.AutoSize = false;
      tslFilter.AutoToolTip = true;
      tslFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      tslFilter.Image = global::BeatSaber_Playlist_Editor.Properties.Resources._20x20_Search;
      tslFilter.Name = "tslFilter";
      tslFilter.Size = new System.Drawing.Size(22, 22);
      tslFilter.Text = "Filter";
      tslFilter.ToolTipText = "Filter";
      // 
      // tstbSongFilter
      // 
      tstbSongFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      tstbSongFilter.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsViewModel, "SongFilterText", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      tstbSongFilter.Name = "tstbSongFilter";
      tstbSongFilter.Size = new System.Drawing.Size(116, 25);
      // 
      // tsbModeStandard
      // 
      tsbModeStandard.CheckOnClick = true;
      tsbModeStandard.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bsViewModel, "IsStandardGameModeVisible", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      tsbModeStandard.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      tsbModeStandard.Image = global::BeatSaber_Playlist_Editor.Properties.Resources._24x24_TwoSabers;
      tsbModeStandard.ImageTransparentColor = System.Drawing.Color.Magenta;
      tsbModeStandard.Name = "tsbModeStandard";
      tsbModeStandard.Size = new System.Drawing.Size(23, 22);
      tsbModeStandard.Text = "Standard";
      // 
      // tsbModeOneSaber
      // 
      tsbModeOneSaber.CheckOnClick = true;
      tsbModeOneSaber.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bsViewModel, "IsOneSaberGameModeVisible", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      tsbModeOneSaber.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      tsbModeOneSaber.Image = global::BeatSaber_Playlist_Editor.Properties.Resources._24x24_OneSaber;
      tsbModeOneSaber.ImageTransparentColor = System.Drawing.Color.Magenta;
      tsbModeOneSaber.Name = "tsbModeOneSaber";
      tsbModeOneSaber.Size = new System.Drawing.Size(23, 22);
      tsbModeOneSaber.Text = "One Saber";
      // 
      // tsbModeNoArrows
      // 
      tsbModeNoArrows.CheckOnClick = true;
      tsbModeNoArrows.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bsViewModel, "IsNoArrowsGameModeVisible", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      tsbModeNoArrows.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      tsbModeNoArrows.Image = global::BeatSaber_Playlist_Editor.Properties.Resources._24x24_NoArrows;
      tsbModeNoArrows.ImageTransparentColor = System.Drawing.Color.Magenta;
      tsbModeNoArrows.Name = "tsbModeNoArrows";
      tsbModeNoArrows.Size = new System.Drawing.Size(23, 22);
      tsbModeNoArrows.Text = "No Arrows";
      // 
      // tsbMode90
      // 
      tsbMode90.CheckOnClick = true;
      tsbMode90.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bsViewModel, "Is90GameModeVisible", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      tsbMode90.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      tsbMode90.Image = global::BeatSaber_Playlist_Editor.Properties.Resources._24x24_90degrees;
      tsbMode90.ImageTransparentColor = System.Drawing.Color.Magenta;
      tsbMode90.Name = "tsbMode90";
      tsbMode90.Size = new System.Drawing.Size(23, 22);
      tsbMode90.Text = "90°";
      // 
      // tsbMode360
      // 
      tsbMode360.CheckOnClick = true;
      tsbMode360.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bsViewModel, "Is360GameModeVisible", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      tsbMode360.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      tsbMode360.Image = global::BeatSaber_Playlist_Editor.Properties.Resources._24x24_360degrees;
      tsbMode360.ImageTransparentColor = System.Drawing.Color.Magenta;
      tsbMode360.Name = "tsbMode360";
      tsbMode360.Size = new System.Drawing.Size(23, 22);
      tsbMode360.Text = "360°";
      // 
      // gbSongProperties
      // 
      gbSongProperties.Controls.Add(tlpSongProperties);
      gbSongProperties.Dock = System.Windows.Forms.DockStyle.Fill;
      gbSongProperties.Location = new System.Drawing.Point(0, 0);
      gbSongProperties.Name = "gbSongProperties";
      gbSongProperties.Size = new System.Drawing.Size(287, 201);
      gbSongProperties.TabIndex = 0;
      gbSongProperties.TabStop = false;
      gbSongProperties.Text = "Song properties";
      // 
      // tlpSongProperties
      // 
      tlpSongProperties.ColumnCount = 2;
      tlpSongProperties.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      tlpSongProperties.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tlpSongProperties.Controls.Add(lSongCoverDetails, 0, 1);
      tlpSongProperties.Controls.Add(pbSongCover, 0, 0);
      tlpSongProperties.Controls.Add(lArtist, 0, 2);
      tlpSongProperties.Controls.Add(lArtistData, 1, 2);
      tlpSongProperties.Controls.Add(lTitleData, 1, 3);
      tlpSongProperties.Controls.Add(lLevelAuthorData, 1, 4);
      tlpSongProperties.Controls.Add(lLevelAuthor, 0, 4);
      tlpSongProperties.Controls.Add(lTitle, 0, 3);
      tlpSongProperties.Controls.Add(lEnvironment, 0, 5);
      tlpSongProperties.Controls.Add(lBeatsPerMinute, 0, 6);
      tlpSongProperties.Controls.Add(lEnvironmentData, 1, 5);
      tlpSongProperties.Controls.Add(lBeatsPerMinuteData, 1, 6);
      tlpSongProperties.Dock = System.Windows.Forms.DockStyle.Fill;
      tlpSongProperties.Location = new System.Drawing.Point(3, 19);
      tlpSongProperties.Name = "tlpSongProperties";
      tlpSongProperties.RowCount = 7;
      tlpSongProperties.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      tlpSongProperties.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tlpSongProperties.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tlpSongProperties.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tlpSongProperties.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tlpSongProperties.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tlpSongProperties.RowStyles.Add(new System.Windows.Forms.RowStyle());
      tlpSongProperties.Size = new System.Drawing.Size(281, 179);
      tlpSongProperties.TabIndex = 0;
      // 
      // lSongCoverDetails
      // 
      lSongCoverDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
      lSongCoverDetails.AutoSize = true;
      tlpSongProperties.SetColumnSpan(lSongCoverDetails, 2);
      lSongCoverDetails.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsViewModel, "CurrentSong.CoverDetails", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      lSongCoverDetails.Location = new System.Drawing.Point(3, 89);
      lSongCoverDetails.Name = "lSongCoverDetails";
      lSongCoverDetails.Size = new System.Drawing.Size(275, 15);
      lSongCoverDetails.TabIndex = 0;
      lSongCoverDetails.Text = "100 x 100";
      lSongCoverDetails.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // pbSongCover
      // 
      tlpSongProperties.SetColumnSpan(pbSongCover, 2);
      pbSongCover.DataBindings.Add(new System.Windows.Forms.Binding("Image", this.bsViewModel, "CurrentSong.Cover.Image", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      pbSongCover.Dock = System.Windows.Forms.DockStyle.Fill;
      pbSongCover.ErrorImage = global::BeatSaber_Playlist_Editor.Properties.Resources.NoPictureAvailable;
      pbSongCover.Image = global::BeatSaber_Playlist_Editor.Properties.Resources.NoPictureAvailable;
      pbSongCover.InitialImage = global::BeatSaber_Playlist_Editor.Properties.Resources.NoPictureAvailable;
      pbSongCover.Location = new System.Drawing.Point(3, 3);
      pbSongCover.Name = "pbSongCover";
      pbSongCover.Size = new System.Drawing.Size(275, 83);
      pbSongCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
      pbSongCover.TabIndex = 1;
      pbSongCover.TabStop = false;
      // 
      // lArtist
      // 
      lArtist.Anchor = System.Windows.Forms.AnchorStyles.Left;
      lArtist.AutoSize = true;
      lArtist.Location = new System.Drawing.Point(3, 104);
      lArtist.Name = "lArtist";
      lArtist.Size = new System.Drawing.Size(35, 15);
      lArtist.TabIndex = 2;
      lArtist.Text = "Artist";
      // 
      // lArtistData
      // 
      lArtistData.Anchor = System.Windows.Forms.AnchorStyles.Left;
      lArtistData.AutoSize = true;
      lArtistData.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsViewModel, "CurrentSong.Artist", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      lArtistData.Location = new System.Drawing.Point(84, 104);
      lArtistData.Name = "lArtistData";
      lArtistData.Size = new System.Drawing.Size(43, 15);
      lArtistData.TabIndex = 2;
      lArtistData.Text = "{Artist}";
      // 
      // lTitleData
      // 
      lTitleData.Anchor = System.Windows.Forms.AnchorStyles.Left;
      lTitleData.AutoSize = true;
      lTitleData.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsViewModel, "CurrentSong.Title", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      lTitleData.Location = new System.Drawing.Point(84, 119);
      lTitleData.Name = "lTitleData";
      lTitleData.Size = new System.Drawing.Size(37, 15);
      lTitleData.TabIndex = 2;
      lTitleData.Text = "{Title}";
      // 
      // lLevelAuthorData
      // 
      lLevelAuthorData.Anchor = System.Windows.Forms.AnchorStyles.Left;
      lLevelAuthorData.AutoSize = true;
      lLevelAuthorData.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsViewModel, "CurrentSong.LevelAuthor.CurrentSong", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      lLevelAuthorData.Location = new System.Drawing.Point(84, 134);
      lLevelAuthorData.Name = "lLevelAuthorData";
      lLevelAuthorData.Size = new System.Drawing.Size(79, 15);
      lLevelAuthorData.TabIndex = 2;
      lLevelAuthorData.Text = "{LevelAuthor}";
      // 
      // lLevelAuthor
      // 
      lLevelAuthor.Anchor = System.Windows.Forms.AnchorStyles.Left;
      lLevelAuthor.AutoSize = true;
      lLevelAuthor.Location = new System.Drawing.Point(3, 134);
      lLevelAuthor.Name = "lLevelAuthor";
      lLevelAuthor.Size = new System.Drawing.Size(74, 15);
      lLevelAuthor.TabIndex = 2;
      lLevelAuthor.Text = "Level Author";
      // 
      // lTitle
      // 
      lTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
      lTitle.AutoSize = true;
      lTitle.Location = new System.Drawing.Point(3, 119);
      lTitle.Name = "lTitle";
      lTitle.Size = new System.Drawing.Size(29, 15);
      lTitle.TabIndex = 2;
      lTitle.Text = "Title";
      // 
      // lEnvironment
      // 
      lEnvironment.Anchor = System.Windows.Forms.AnchorStyles.Left;
      lEnvironment.AutoSize = true;
      lEnvironment.Location = new System.Drawing.Point(3, 149);
      lEnvironment.Name = "lEnvironment";
      lEnvironment.Size = new System.Drawing.Size(75, 15);
      lEnvironment.TabIndex = 2;
      lEnvironment.Text = "Environment";
      // 
      // lBeatsPerMinute
      // 
      lBeatsPerMinute.Anchor = System.Windows.Forms.AnchorStyles.Left;
      lBeatsPerMinute.AutoSize = true;
      lBeatsPerMinute.Location = new System.Drawing.Point(3, 164);
      lBeatsPerMinute.Name = "lBeatsPerMinute";
      lBeatsPerMinute.Size = new System.Drawing.Size(32, 15);
      lBeatsPerMinute.TabIndex = 2;
      lBeatsPerMinute.Text = "BPM";
      // 
      // lEnvironmentData
      // 
      lEnvironmentData.Anchor = System.Windows.Forms.AnchorStyles.Left;
      lEnvironmentData.AutoSize = true;
      lEnvironmentData.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsViewModel, "CurrentSong.Environment.CurrentSong", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      lEnvironmentData.Location = new System.Drawing.Point(84, 149);
      lEnvironmentData.Name = "lEnvironmentData";
      lEnvironmentData.Size = new System.Drawing.Size(83, 15);
      lEnvironmentData.TabIndex = 2;
      lEnvironmentData.Text = "{Environment}";
      // 
      // lBeatsPerMinuteData
      // 
      lBeatsPerMinuteData.Anchor = System.Windows.Forms.AnchorStyles.Left;
      lBeatsPerMinuteData.AutoSize = true;
      lBeatsPerMinuteData.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsViewModel, "CurrentSong.BeatsPerMinute", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "N0"));
      lBeatsPerMinuteData.Location = new System.Drawing.Point(84, 164);
      lBeatsPerMinuteData.Name = "lBeatsPerMinuteData";
      lBeatsPerMinuteData.Size = new System.Drawing.Size(25, 15);
      lBeatsPerMinuteData.TabIndex = 2;
      lBeatsPerMinuteData.Text = "100";
      // 
      // fbdSelectRoot
      // 
      this.fbdSelectRoot.Description = "Please select the installation path of your BeatSaber.";
      // 
      // ofdSelectImage
      // 
      this.ofdSelectImage.FileName = "Cover";
      this.ofdSelectImage.ReadOnlyChecked = true;
      this.ofdSelectImage.RestoreDirectory = true;
      this.ofdSelectImage.SupportMultiDottedExtensions = true;
      this.ofdSelectImage.Title = "Select image to apply";
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(splitContainer1);
      this.Controls.Add(ssStatus);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "MainForm";
      this.Text = "BeatSaber Playlist Editor";
      splitContainer1.Panel1.ResumeLayout(false);
      splitContainer1.Panel1.PerformLayout();
      splitContainer1.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(splitContainer1)).EndInit();
      splitContainer1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dgvPlaylists)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.bsViewModel)).EndInit();
      tsBeatsaber.ResumeLayout(false);
      tsBeatsaber.PerformLayout();
      splitContainer2.Panel1.ResumeLayout(false);
      splitContainer2.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(splitContainer2)).EndInit();
      splitContainer2.ResumeLayout(false);
      splitContainer4.Panel1.ResumeLayout(false);
      splitContainer4.Panel1.PerformLayout();
      splitContainer4.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(splitContainer4)).EndInit();
      splitContainer4.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dgvPlaylistEntries)).EndInit();
      tsPlaylist.ResumeLayout(false);
      tsPlaylist.PerformLayout();
      gbPlaylistProperties.ResumeLayout(false);
      tlpPlaylistProperties.ResumeLayout(false);
      tlpPlaylistProperties.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(pbPlaylistCover)).EndInit();
      splitContainer3.Panel1.ResumeLayout(false);
      splitContainer3.Panel1.PerformLayout();
      splitContainer3.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(splitContainer3)).EndInit();
      splitContainer3.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dgvSongs)).EndInit();
      tsSongs.ResumeLayout(false);
      tsSongs.PerformLayout();
      gbSongProperties.ResumeLayout(false);
      tlpSongProperties.ResumeLayout(false);
      tlpSongProperties.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(pbSongCover)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private DataGridView dgvPlaylists;
    private DataGridView dgvPlaylistEntries;
    private BindingSource bsViewModel;
    private FolderBrowserDialog fbdSelectRoot;
    private DataGridView dgvSongs;
    private OpenFileDialog ofdSelectImage;
    private TextBox tbPlaylistName;
  }
}