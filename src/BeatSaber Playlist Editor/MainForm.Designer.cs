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
      System.Windows.Forms.StatusStrip statusStrip1;
      System.Windows.Forms.SplitContainer splitContainer1;
      System.Windows.Forms.DataGridView dgvPlaylists;
      System.Windows.Forms.ToolStrip tsBeatsaber;
      System.Windows.Forms.SplitContainer splitContainer2;
      System.Windows.Forms.SplitContainer splitContainer4;
      System.Windows.Forms.DataGridView dgvPlaylistEntries;
      System.Windows.Forms.ToolStrip tsPlaylist;
      System.Windows.Forms.GroupBox groupBox1;
      System.Windows.Forms.SplitContainer splitContainer3;
      System.Windows.Forms.DataGridView dgvSongs;
      System.Windows.Forms.ToolStrip tsSongs;
      System.Windows.Forms.ToolStripLabel tslFilter;
      System.Windows.Forms.GroupBox groupBox2;
      this.nameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.authorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.bsViewModel = new System.Windows.Forms.BindingSource(this.components);
      this.playlistsBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.tsbBeatsaberSetPath = new System.Windows.Forms.BindableToolStripButton();
      this.tsbBeatsaberRefresh = new System.Windows.Forms.BindableToolStripButton();
      this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.currentPlaylistEntriesBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.tsbPlaylistSave = new System.Windows.Forms.BindableToolStripButton();
      this.tsbEntryFirst = new System.Windows.Forms.BindableToolStripButton();
      this.tsbEntryUp = new System.Windows.Forms.BindableToolStripButton();
      this.tsbEntryRemove = new System.Windows.Forms.BindableToolStripButton();
      this.tsbEntryDown = new System.Windows.Forms.BindableToolStripButton();
      this.tsbEntryLast = new System.Windows.Forms.BindableToolStripButton();
      this.tsbEntryClear = new System.Windows.Forms.BindableToolStripButton();
      this.tsbPlaylistReread = new System.Windows.Forms.BindableToolStripButton();
      this.artistDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.songsBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.tstbSongFilter = new System.Windows.Forms.BindableToolStripSpringTextBox();
      this.tsbModeStandard = new System.Windows.Forms.BindableToolStripButton();
      this.tsbModeOneSaber = new System.Windows.Forms.BindableToolStripButton();
      this.tsbModeNoArrows = new System.Windows.Forms.BindableToolStripButton();
      this.tsbMode90 = new System.Windows.Forms.BindableToolStripButton();
      this.tsbMode360 = new System.Windows.Forms.BindableToolStripButton();
      this.fbdSelectRoot = new System.Windows.Forms.FolderBrowserDialog();
      statusStrip1 = new System.Windows.Forms.StatusStrip();
      splitContainer1 = new System.Windows.Forms.SplitContainer();
      dgvPlaylists = new System.Windows.Forms.DataGridView();
      tsBeatsaber = new System.Windows.Forms.ToolStrip();
      splitContainer2 = new System.Windows.Forms.SplitContainer();
      splitContainer4 = new System.Windows.Forms.SplitContainer();
      dgvPlaylistEntries = new System.Windows.Forms.DataGridView();
      tsPlaylist = new System.Windows.Forms.ToolStrip();
      groupBox1 = new System.Windows.Forms.GroupBox();
      splitContainer3 = new System.Windows.Forms.SplitContainer();
      dgvSongs = new System.Windows.Forms.DataGridView();
      tsSongs = new System.Windows.Forms.ToolStrip();
      tslFilter = new System.Windows.Forms.ToolStripLabel();
      groupBox2 = new System.Windows.Forms.GroupBox();
      ((System.ComponentModel.ISupportInitialize)(splitContainer1)).BeginInit();
      splitContainer1.Panel1.SuspendLayout();
      splitContainer1.Panel2.SuspendLayout();
      splitContainer1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(dgvPlaylists)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.bsViewModel)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.playlistsBindingSource)).BeginInit();
      tsBeatsaber.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(splitContainer2)).BeginInit();
      splitContainer2.Panel1.SuspendLayout();
      splitContainer2.Panel2.SuspendLayout();
      splitContainer2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(splitContainer4)).BeginInit();
      splitContainer4.Panel1.SuspendLayout();
      splitContainer4.Panel2.SuspendLayout();
      splitContainer4.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(dgvPlaylistEntries)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.currentPlaylistEntriesBindingSource)).BeginInit();
      tsPlaylist.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(splitContainer3)).BeginInit();
      splitContainer3.Panel1.SuspendLayout();
      splitContainer3.Panel2.SuspendLayout();
      splitContainer3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(dgvSongs)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.songsBindingSource)).BeginInit();
      tsSongs.SuspendLayout();
      this.SuspendLayout();
      // 
      // statusStrip1
      // 
      statusStrip1.Location = new System.Drawing.Point(0, 428);
      statusStrip1.Name = "statusStrip1";
      statusStrip1.Size = new System.Drawing.Size(800, 22);
      statusStrip1.TabIndex = 0;
      statusStrip1.Text = "statusStrip1";
      // 
      // splitContainer1
      // 
      splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      splitContainer1.Location = new System.Drawing.Point(0, 0);
      splitContainer1.Name = "splitContainer1";
      // 
      // splitContainer1.Panel1
      // 
      splitContainer1.Panel1.Controls.Add(dgvPlaylists);
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
      dgvPlaylists.AllowUserToAddRows = false;
      dgvPlaylists.AllowUserToDeleteRows = false;
      dgvPlaylists.AllowUserToOrderColumns = true;
      dgvPlaylists.AllowUserToResizeRows = false;
      dgvPlaylists.AutoGenerateColumns = false;
      dgvPlaylists.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      dgvPlaylists.BackgroundColor = System.Drawing.SystemColors.Window;
      dgvPlaylists.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      dgvPlaylists.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      dgvPlaylists.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn1,
            this.authorDataGridViewTextBoxColumn});
      dgvPlaylists.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.bsViewModel, "IsPlaylistsAvailable", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      dgvPlaylists.DataSource = this.playlistsBindingSource;
      dgvPlaylists.Dock = System.Windows.Forms.DockStyle.Fill;
      dgvPlaylists.Location = new System.Drawing.Point(0, 25);
      dgvPlaylists.MultiSelect = false;
      dgvPlaylists.Name = "dgvPlaylists";
      dgvPlaylists.ReadOnly = true;
      dgvPlaylists.RowHeadersVisible = false;
      dgvPlaylists.RowTemplate.Height = 25;
      dgvPlaylists.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      dgvPlaylists.Size = new System.Drawing.Size(266, 403);
      dgvPlaylists.TabIndex = 1;
      dgvPlaylists.SelectionChanged += new System.EventHandler(this.dgvPlaylists_SelectionChanged);
      // 
      // nameDataGridViewTextBoxColumn1
      // 
      this.nameDataGridViewTextBoxColumn1.DataPropertyName = "Name";
      this.nameDataGridViewTextBoxColumn1.HeaderText = "Name";
      this.nameDataGridViewTextBoxColumn1.Name = "nameDataGridViewTextBoxColumn1";
      this.nameDataGridViewTextBoxColumn1.ReadOnly = true;
      // 
      // authorDataGridViewTextBoxColumn
      // 
      this.authorDataGridViewTextBoxColumn.DataPropertyName = "Author";
      this.authorDataGridViewTextBoxColumn.HeaderText = "Author";
      this.authorDataGridViewTextBoxColumn.Name = "authorDataGridViewTextBoxColumn";
      this.authorDataGridViewTextBoxColumn.ReadOnly = true;
      // 
      // bsViewModel
      // 
      this.bsViewModel.AllowNew = false;
      this.bsViewModel.DataSource = typeof(BeatSaber_Playlist_Editor.ViewModel.UIMain);
      // 
      // playlistsBindingSource
      // 
      this.playlistsBindingSource.DataMember = "Playlists";
      this.playlistsBindingSource.DataSource = this.bsViewModel;
      // 
      // tsBeatsaber
      // 
      tsBeatsaber.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
      tsBeatsaber.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbBeatsaberSetPath,
            this.tsbBeatsaberRefresh});
      tsBeatsaber.Location = new System.Drawing.Point(0, 0);
      tsBeatsaber.Name = "tsBeatsaber";
      tsBeatsaber.Size = new System.Drawing.Size(266, 25);
      tsBeatsaber.TabIndex = 0;
      tsBeatsaber.Text = "Beatsaber";
      // 
      // tsbBeatsaberSetPath
      // 
      this.tsbBeatsaberSetPath.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbBeatsaberSetPath.Image = global::BeatSaber_Playlist_Editor.Properties.Resources._20x20_BeatSaber;
      this.tsbBeatsaberSetPath.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbBeatsaberSetPath.Name = "tsbBeatsaberSetPath";
      this.tsbBeatsaberSetPath.Size = new System.Drawing.Size(23, 22);
      this.tsbBeatsaberSetPath.Text = "Select BeatSaber Installation";
      this.tsbBeatsaberSetPath.Click += new System.EventHandler(this.tsbBeatsaberSetPath_Click);
      // 
      // tsbBeatsaberRefresh
      // 
      this.tsbBeatsaberRefresh.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.bsViewModel, "IsRefreshAvailable", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.tsbBeatsaberRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbBeatsaberRefresh.Image = global::BeatSaber_Playlist_Editor.Properties.Resources._16x16_Refresh;
      this.tsbBeatsaberRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbBeatsaberRefresh.Name = "tsbBeatsaberRefresh";
      this.tsbBeatsaberRefresh.Size = new System.Drawing.Size(23, 22);
      this.tsbBeatsaberRefresh.Text = "Refresh";
      this.tsbBeatsaberRefresh.Click += new System.EventHandler(this.tsbBeatsaberRefresh_Click);
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
      splitContainer4.Panel1.Controls.Add(dgvPlaylistEntries);
      splitContainer4.Panel1.Controls.Add(tsPlaylist);
      // 
      // splitContainer4.Panel2
      // 
      splitContainer4.Panel2.Controls.Add(groupBox1);
      splitContainer4.Size = new System.Drawing.Size(239, 428);
      splitContainer4.SplitterDistance = 225;
      splitContainer4.TabIndex = 0;
      // 
      // dgvPlaylistEntries
      // 
      dgvPlaylistEntries.AllowUserToAddRows = false;
      dgvPlaylistEntries.AllowUserToDeleteRows = false;
      dgvPlaylistEntries.AllowUserToResizeRows = false;
      dgvPlaylistEntries.AutoGenerateColumns = false;
      dgvPlaylistEntries.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      dgvPlaylistEntries.BackgroundColor = System.Drawing.SystemColors.Window;
      dgvPlaylistEntries.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      dgvPlaylistEntries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      dgvPlaylistEntries.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn});
      dgvPlaylistEntries.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.bsViewModel, "IsCurrentPlaylistAvailable", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      dgvPlaylistEntries.DataSource = this.currentPlaylistEntriesBindingSource;
      dgvPlaylistEntries.Dock = System.Windows.Forms.DockStyle.Fill;
      dgvPlaylistEntries.Location = new System.Drawing.Point(0, 25);
      dgvPlaylistEntries.Name = "dgvPlaylistEntries";
      dgvPlaylistEntries.ReadOnly = true;
      dgvPlaylistEntries.RowHeadersVisible = false;
      dgvPlaylistEntries.RowTemplate.Height = 25;
      dgvPlaylistEntries.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      dgvPlaylistEntries.Size = new System.Drawing.Size(239, 200);
      dgvPlaylistEntries.TabIndex = 1;
      // 
      // nameDataGridViewTextBoxColumn
      // 
      this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
      this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
      this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
      this.nameDataGridViewTextBoxColumn.ReadOnly = true;
      // 
      // currentPlaylistEntriesBindingSource
      // 
      this.currentPlaylistEntriesBindingSource.DataMember = "CurrentPlaylistEntries";
      this.currentPlaylistEntriesBindingSource.DataSource = this.bsViewModel;
      // 
      // tsPlaylist
      // 
      tsPlaylist.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.bsViewModel, "IsCurrentPlaylistAvailable", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      tsPlaylist.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
      tsPlaylist.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbPlaylistSave,
            this.tsbEntryFirst,
            this.tsbEntryUp,
            this.tsbEntryRemove,
            this.tsbEntryDown,
            this.tsbEntryLast,
            this.tsbEntryClear,
            this.tsbPlaylistReread});
      tsPlaylist.Location = new System.Drawing.Point(0, 0);
      tsPlaylist.Name = "tsPlaylist";
      tsPlaylist.Size = new System.Drawing.Size(239, 25);
      tsPlaylist.TabIndex = 0;
      tsPlaylist.Text = "Playlist";
      // 
      // tsbPlaylistSave
      // 
      this.tsbPlaylistSave.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.bsViewModel, "IsCurrentPlaylistSaveAvailable", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.tsbPlaylistSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbPlaylistSave.Image = global::BeatSaber_Playlist_Editor.Properties.Resources._16x16_Save;
      this.tsbPlaylistSave.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbPlaylistSave.Name = "tsbPlaylistSave";
      this.tsbPlaylistSave.Size = new System.Drawing.Size(23, 22);
      this.tsbPlaylistSave.Text = "Save";
      // 
      // tsbEntryFirst
      // 
      this.tsbEntryFirst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbEntryFirst.Image = global::BeatSaber_Playlist_Editor.Properties.Resources._20x20_First;
      this.tsbEntryFirst.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbEntryFirst.Name = "tsbEntryFirst";
      this.tsbEntryFirst.Size = new System.Drawing.Size(23, 22);
      this.tsbEntryFirst.Text = "First";
      // 
      // tsbEntryUp
      // 
      this.tsbEntryUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbEntryUp.Image = global::BeatSaber_Playlist_Editor.Properties.Resources._20x20_Up;
      this.tsbEntryUp.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbEntryUp.Name = "tsbEntryUp";
      this.tsbEntryUp.Size = new System.Drawing.Size(23, 22);
      this.tsbEntryUp.Text = "Up";
      // 
      // tsbEntryRemove
      // 
      this.tsbEntryRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbEntryRemove.Image = global::BeatSaber_Playlist_Editor.Properties.Resources._20x20_Remove;
      this.tsbEntryRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbEntryRemove.Name = "tsbEntryRemove";
      this.tsbEntryRemove.Size = new System.Drawing.Size(23, 22);
      this.tsbEntryRemove.Text = "Remove";
      // 
      // tsbEntryDown
      // 
      this.tsbEntryDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbEntryDown.Image = global::BeatSaber_Playlist_Editor.Properties.Resources._20x20_Down;
      this.tsbEntryDown.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbEntryDown.Name = "tsbEntryDown";
      this.tsbEntryDown.Size = new System.Drawing.Size(23, 22);
      this.tsbEntryDown.Text = "Down";
      // 
      // tsbEntryLast
      // 
      this.tsbEntryLast.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbEntryLast.Image = global::BeatSaber_Playlist_Editor.Properties.Resources._20x20_Last;
      this.tsbEntryLast.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbEntryLast.Name = "tsbEntryLast";
      this.tsbEntryLast.Size = new System.Drawing.Size(23, 22);
      this.tsbEntryLast.Text = "Last";
      // 
      // tsbEntryClear
      // 
      this.tsbEntryClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbEntryClear.Image = global::BeatSaber_Playlist_Editor.Properties.Resources._16x16_Clear;
      this.tsbEntryClear.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbEntryClear.Name = "tsbEntryClear";
      this.tsbEntryClear.Size = new System.Drawing.Size(23, 22);
      this.tsbEntryClear.Text = "Clear";
      // 
      // tsbPlaylistReread
      // 
      this.tsbPlaylistReread.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbPlaylistReread.Image = global::BeatSaber_Playlist_Editor.Properties.Resources._24x24_Reread;
      this.tsbPlaylistReread.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbPlaylistReread.Name = "tsbPlaylistReread";
      this.tsbPlaylistReread.Size = new System.Drawing.Size(23, 22);
      this.tsbPlaylistReread.Text = "Re-read";
      // 
      // groupBox1
      // 
      groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      groupBox1.Location = new System.Drawing.Point(0, 0);
      groupBox1.Name = "groupBox1";
      groupBox1.Size = new System.Drawing.Size(239, 199);
      groupBox1.TabIndex = 0;
      groupBox1.TabStop = false;
      groupBox1.Text = "Playlist properties";
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
      splitContainer3.Panel1.Controls.Add(dgvSongs);
      splitContainer3.Panel1.Controls.Add(tsSongs);
      // 
      // splitContainer3.Panel2
      // 
      splitContainer3.Panel2.Controls.Add(groupBox2);
      splitContainer3.Size = new System.Drawing.Size(287, 428);
      splitContainer3.SplitterDistance = 223;
      splitContainer3.TabIndex = 0;
      // 
      // dgvSongs
      // 
      dgvSongs.AllowUserToAddRows = false;
      dgvSongs.AllowUserToDeleteRows = false;
      dgvSongs.AllowUserToResizeRows = false;
      dgvSongs.AutoGenerateColumns = false;
      dgvSongs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      dgvSongs.BackgroundColor = System.Drawing.SystemColors.Window;
      dgvSongs.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      dgvSongs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      dgvSongs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.artistDataGridViewTextBoxColumn,
            this.titleDataGridViewTextBoxColumn});
      dgvSongs.DataSource = this.songsBindingSource;
      dgvSongs.Dock = System.Windows.Forms.DockStyle.Fill;
      dgvSongs.Location = new System.Drawing.Point(0, 25);
      dgvSongs.Name = "dgvSongs";
      dgvSongs.ReadOnly = true;
      dgvSongs.RowHeadersVisible = false;
      dgvSongs.RowTemplate.Height = 25;
      dgvSongs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      dgvSongs.Size = new System.Drawing.Size(287, 198);
      dgvSongs.TabIndex = 1;
      // 
      // artistDataGridViewTextBoxColumn
      // 
      this.artistDataGridViewTextBoxColumn.DataPropertyName = "Artist";
      this.artistDataGridViewTextBoxColumn.HeaderText = "Artist";
      this.artistDataGridViewTextBoxColumn.Name = "artistDataGridViewTextBoxColumn";
      this.artistDataGridViewTextBoxColumn.ReadOnly = true;
      // 
      // titleDataGridViewTextBoxColumn
      // 
      this.titleDataGridViewTextBoxColumn.DataPropertyName = "Title";
      this.titleDataGridViewTextBoxColumn.HeaderText = "Title";
      this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
      this.titleDataGridViewTextBoxColumn.ReadOnly = true;
      // 
      // songsBindingSource
      // 
      this.songsBindingSource.DataMember = "Songs";
      this.songsBindingSource.DataSource = this.bsViewModel;
      // 
      // tsSongs
      // 
      tsSongs.CanOverflow = false;
      tsSongs.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.bsViewModel, "IsSongsAvailable", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      tsSongs.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
      tsSongs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            tslFilter,
            this.tstbSongFilter,
            this.tsbModeStandard,
            this.tsbModeOneSaber,
            this.tsbModeNoArrows,
            this.tsbMode90,
            this.tsbMode360});
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
      this.tstbSongFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.tstbSongFilter.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bsViewModel, "SongFilterText", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.tstbSongFilter.Name = "tstbSongFilter";
      this.tstbSongFilter.Size = new System.Drawing.Size(116, 25);
      // 
      // tsbModeStandard
      // 
      this.tsbModeStandard.Checked = true;
      this.tsbModeStandard.CheckOnClick = true;
      this.tsbModeStandard.CheckState = System.Windows.Forms.CheckState.Checked;
      this.tsbModeStandard.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bsViewModel, "IsStandardGameModeVisible", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.tsbModeStandard.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbModeStandard.Image = global::BeatSaber_Playlist_Editor.Properties.Resources._24x24_TwoSabers;
      this.tsbModeStandard.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbModeStandard.Name = "tsbModeStandard";
      this.tsbModeStandard.Size = new System.Drawing.Size(23, 22);
      this.tsbModeStandard.Text = "Standard";
      // 
      // tsbModeOneSaber
      // 
      this.tsbModeOneSaber.Checked = true;
      this.tsbModeOneSaber.CheckOnClick = true;
      this.tsbModeOneSaber.CheckState = System.Windows.Forms.CheckState.Checked;
      this.tsbModeOneSaber.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bsViewModel, "IsOneSaberGameModeVisible", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.tsbModeOneSaber.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbModeOneSaber.Image = global::BeatSaber_Playlist_Editor.Properties.Resources._24x24_OneSaber;
      this.tsbModeOneSaber.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbModeOneSaber.Name = "tsbModeOneSaber";
      this.tsbModeOneSaber.Size = new System.Drawing.Size(23, 22);
      this.tsbModeOneSaber.Text = "One Saber";
      // 
      // tsbModeNoArrows
      // 
      this.tsbModeNoArrows.Checked = true;
      this.tsbModeNoArrows.CheckOnClick = true;
      this.tsbModeNoArrows.CheckState = System.Windows.Forms.CheckState.Checked;
      this.tsbModeNoArrows.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bsViewModel, "IsNoArrowsGameModeVisible", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.tsbModeNoArrows.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbModeNoArrows.Image = global::BeatSaber_Playlist_Editor.Properties.Resources._24x24_NoArrows;
      this.tsbModeNoArrows.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbModeNoArrows.Name = "tsbModeNoArrows";
      this.tsbModeNoArrows.Size = new System.Drawing.Size(23, 22);
      this.tsbModeNoArrows.Text = "No Arrows";
      // 
      // tsbMode90
      // 
      this.tsbMode90.Checked = true;
      this.tsbMode90.CheckOnClick = true;
      this.tsbMode90.CheckState = System.Windows.Forms.CheckState.Checked;
      this.tsbMode90.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bsViewModel, "Is90GameModeVisible", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.tsbMode90.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbMode90.Image = global::BeatSaber_Playlist_Editor.Properties.Resources._24x24_90degrees;
      this.tsbMode90.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbMode90.Name = "tsbMode90";
      this.tsbMode90.Size = new System.Drawing.Size(23, 22);
      this.tsbMode90.Text = "90°";
      // 
      // tsbMode360
      // 
      this.tsbMode360.Checked = true;
      this.tsbMode360.CheckOnClick = true;
      this.tsbMode360.CheckState = System.Windows.Forms.CheckState.Checked;
      this.tsbMode360.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bsViewModel, "Is360GameModeVisible", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.tsbMode360.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbMode360.Image = global::BeatSaber_Playlist_Editor.Properties.Resources._24x24_360degrees;
      this.tsbMode360.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbMode360.Name = "tsbMode360";
      this.tsbMode360.Size = new System.Drawing.Size(23, 22);
      this.tsbMode360.Text = "360°";
      // 
      // groupBox2
      // 
      groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
      groupBox2.Location = new System.Drawing.Point(0, 0);
      groupBox2.Name = "groupBox2";
      groupBox2.Size = new System.Drawing.Size(287, 201);
      groupBox2.TabIndex = 0;
      groupBox2.TabStop = false;
      groupBox2.Text = "Song properties";
      // 
      // fbdSelectRoot
      // 
      this.fbdSelectRoot.Description = "Please select the installation path of your BeatSaber.";
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(splitContainer1);
      this.Controls.Add(statusStrip1);
      this.Name = "MainForm";
      this.Text = "BeatSaber Playlist Editor";
      splitContainer1.Panel1.ResumeLayout(false);
      splitContainer1.Panel1.PerformLayout();
      splitContainer1.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(splitContainer1)).EndInit();
      splitContainer1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(dgvPlaylists)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.bsViewModel)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.playlistsBindingSource)).EndInit();
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
      ((System.ComponentModel.ISupportInitialize)(dgvPlaylistEntries)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.currentPlaylistEntriesBindingSource)).EndInit();
      tsPlaylist.ResumeLayout(false);
      tsPlaylist.PerformLayout();
      splitContainer3.Panel1.ResumeLayout(false);
      splitContainer3.Panel1.PerformLayout();
      splitContainer3.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(splitContainer3)).EndInit();
      splitContainer3.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(dgvSongs)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.songsBindingSource)).EndInit();
      tsSongs.ResumeLayout(false);
      tsSongs.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private DataGridView dgvPlaylists;
    private DataGridView dgvPlaylistEntries;
    private BindableToolStripSpringTextBox tstbSongFilter;
    private BindableToolStripButton tsbModeOneSaber;
    private BindableToolStripButton tsbModeStandard;
    private BindableToolStripButton tsbModeNoArrows;
    private BindableToolStripButton tsbMode90;
    private BindableToolStripButton tsbMode360;
    private BindableToolStripButton tsbEntryClear;
    private BindableToolStripButton tsbEntryRemove;
    private BindableToolStripButton tsbEntryLast;
    private BindableToolStripButton tsbEntryFirst;
    private BindableToolStripButton tsbEntryDown;
    private BindableToolStripButton tsbEntryUp;
    private BindableToolStripButton tsbPlaylistSave;
    private BindableToolStripButton tsbPlaylistReread;
    private BindableToolStripButton tsbBeatsaberSetPath;
    private BindableToolStripButton tsbBeatsaberRefresh;
        private BindingSource bsViewModel;
        private DataGridViewTextBoxColumn sourceDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn authorDataGridViewTextBoxColumn;
        private BindingSource playlistsBindingSource;
        private DataGridViewTextBoxColumn sourceDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private BindingSource currentPlaylistEntriesBindingSource;
        private FolderBrowserDialog fbdSelectRoot;
        private DataGridView dgvSongs;
        private DataGridViewTextBoxColumn artistDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private BindingSource songsBindingSource;
    }
}