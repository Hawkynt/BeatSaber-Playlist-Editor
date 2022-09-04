using BeatSaber_Playlist_Editor.UserControls;

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
      System.Windows.Forms.StatusStrip statusStrip1;
      System.Windows.Forms.SplitContainer splitContainer1;
      System.Windows.Forms.ToolStrip tsBeatsaber;
      System.Windows.Forms.SplitContainer splitContainer2;
      System.Windows.Forms.SplitContainer splitContainer4;
      System.Windows.Forms.ToolStrip tsPlaylist;
      System.Windows.Forms.GroupBox groupBox1;
      System.Windows.Forms.SplitContainer splitContainer3;
      System.Windows.Forms.ToolStrip tsSongs;
      System.Windows.Forms.ToolStripLabel tslFilter;
      System.Windows.Forms.GroupBox groupBox2;
      this.dgvPlaylists = new System.Windows.Forms.DataGridView();
      this.tsbBeatsaberSetPath = new System.Windows.Forms.ToolStripButton();
      this.tsbBeatsaberRefresh = new System.Windows.Forms.ToolStripButton();
      this.dgvPlaylistEntries = new System.Windows.Forms.DataGridView();
      this.tsbPlaylistSave = new System.Windows.Forms.ToolStripButton();
      this.tsbEntryFirst = new System.Windows.Forms.ToolStripButton();
      this.tsbEntryUp = new System.Windows.Forms.ToolStripButton();
      this.tsbEntryRemove = new System.Windows.Forms.ToolStripButton();
      this.tsbEntryDown = new System.Windows.Forms.ToolStripButton();
      this.tsbEntryLast = new System.Windows.Forms.ToolStripButton();
      this.tsbEntryClear = new System.Windows.Forms.ToolStripButton();
      this.tsbPlaylistReread = new System.Windows.Forms.ToolStripButton();
      this.lvSongs = new System.Windows.Forms.ListView();
      this.tstbSongFilter = new BeatSaber_Playlist_Editor.UserControls.ToolStripSpringTextBox();
      this.tsbModeStandard = new System.Windows.Forms.ToolStripButton();
      this.tsbModeOneSaber = new System.Windows.Forms.ToolStripButton();
      this.tsbModeNoArrows = new System.Windows.Forms.ToolStripButton();
      this.tsbMode90 = new System.Windows.Forms.ToolStripButton();
      this.tsbMode360 = new System.Windows.Forms.ToolStripButton();
      statusStrip1 = new System.Windows.Forms.StatusStrip();
      splitContainer1 = new System.Windows.Forms.SplitContainer();
      tsBeatsaber = new System.Windows.Forms.ToolStrip();
      splitContainer2 = new System.Windows.Forms.SplitContainer();
      splitContainer4 = new System.Windows.Forms.SplitContainer();
      tsPlaylist = new System.Windows.Forms.ToolStrip();
      groupBox1 = new System.Windows.Forms.GroupBox();
      splitContainer3 = new System.Windows.Forms.SplitContainer();
      tsSongs = new System.Windows.Forms.ToolStrip();
      tslFilter = new System.Windows.Forms.ToolStripLabel();
      groupBox2 = new System.Windows.Forms.GroupBox();
      ((System.ComponentModel.ISupportInitialize)(splitContainer1)).BeginInit();
      splitContainer1.Panel1.SuspendLayout();
      splitContainer1.Panel2.SuspendLayout();
      splitContainer1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgvPlaylists)).BeginInit();
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
      ((System.ComponentModel.ISupportInitialize)(splitContainer3)).BeginInit();
      splitContainer3.Panel1.SuspendLayout();
      splitContainer3.Panel2.SuspendLayout();
      splitContainer3.SuspendLayout();
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
      this.dgvPlaylists.BackgroundColor = System.Drawing.SystemColors.Window;
      this.dgvPlaylists.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.dgvPlaylists.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvPlaylists.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dgvPlaylists.Location = new System.Drawing.Point(0, 25);
      this.dgvPlaylists.Name = "dgvPlaylists";
      this.dgvPlaylists.ReadOnly = true;
      this.dgvPlaylists.RowHeadersVisible = false;
      this.dgvPlaylists.RowTemplate.Height = 25;
      this.dgvPlaylists.Size = new System.Drawing.Size(266, 403);
      this.dgvPlaylists.TabIndex = 1;
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
      // 
      // tsbBeatsaberRefresh
      // 
      this.tsbBeatsaberRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.tsbBeatsaberRefresh.Image = global::BeatSaber_Playlist_Editor.Properties.Resources._16x16_Refresh;
      this.tsbBeatsaberRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbBeatsaberRefresh.Name = "tsbBeatsaberRefresh";
      this.tsbBeatsaberRefresh.Size = new System.Drawing.Size(23, 22);
      this.tsbBeatsaberRefresh.Text = "Refresh";
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
      splitContainer4.Panel2.Controls.Add(groupBox1);
      splitContainer4.Size = new System.Drawing.Size(239, 428);
      splitContainer4.SplitterDistance = 225;
      splitContainer4.TabIndex = 0;
      // 
      // dgvPlaylistEntries
      // 
      this.dgvPlaylistEntries.AllowUserToAddRows = false;
      this.dgvPlaylistEntries.AllowUserToDeleteRows = false;
      this.dgvPlaylistEntries.AllowUserToResizeRows = false;
      this.dgvPlaylistEntries.BackgroundColor = System.Drawing.SystemColors.Window;
      this.dgvPlaylistEntries.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.dgvPlaylistEntries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvPlaylistEntries.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dgvPlaylistEntries.Location = new System.Drawing.Point(0, 25);
      this.dgvPlaylistEntries.Name = "dgvPlaylistEntries";
      this.dgvPlaylistEntries.ReadOnly = true;
      this.dgvPlaylistEntries.RowHeadersVisible = false;
      this.dgvPlaylistEntries.RowTemplate.Height = 25;
      this.dgvPlaylistEntries.Size = new System.Drawing.Size(239, 200);
      this.dgvPlaylistEntries.TabIndex = 1;
      // 
      // tsPlaylist
      // 
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
      splitContainer3.Panel1.Controls.Add(this.lvSongs);
      splitContainer3.Panel1.Controls.Add(tsSongs);
      // 
      // splitContainer3.Panel2
      // 
      splitContainer3.Panel2.Controls.Add(groupBox2);
      splitContainer3.Size = new System.Drawing.Size(287, 428);
      splitContainer3.SplitterDistance = 223;
      splitContainer3.TabIndex = 0;
      // 
      // lvSongs
      // 
      this.lvSongs.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lvSongs.Location = new System.Drawing.Point(0, 25);
      this.lvSongs.Name = "lvSongs";
      this.lvSongs.Size = new System.Drawing.Size(287, 198);
      this.lvSongs.TabIndex = 1;
      this.lvSongs.UseCompatibleStateImageBehavior = false;
      // 
      // tsSongs
      // 
      tsSongs.CanOverflow = false;
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
      tslFilter.AutoToolTip = true;
      tslFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      tslFilter.Image = global::BeatSaber_Playlist_Editor.Properties.Resources._20x20_Search;
      tslFilter.Name = "tslFilter";
      tslFilter.Size = new System.Drawing.Size(16, 22);
      tslFilter.Text = "Filter";
      tslFilter.ToolTipText = "Filter";
      // 
      // tstbSongFilter
      // 
      this.tstbSongFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.tstbSongFilter.Name = "tstbSongFilter";
      this.tstbSongFilter.Size = new System.Drawing.Size(122, 25);
      // 
      // tsbModeStandard
      // 
      this.tsbModeStandard.Checked = true;
      this.tsbModeStandard.CheckOnClick = true;
      this.tsbModeStandard.CheckState = System.Windows.Forms.CheckState.Checked;
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
      ((System.ComponentModel.ISupportInitialize)(this.dgvPlaylists)).EndInit();
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
      splitContainer3.Panel1.ResumeLayout(false);
      splitContainer3.Panel1.PerformLayout();
      splitContainer3.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(splitContainer3)).EndInit();
      splitContainer3.ResumeLayout(false);
      tsSongs.ResumeLayout(false);
      tsSongs.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private DataGridView dgvPlaylists;
    private DataGridView dgvPlaylistEntries;
    private ListView lvSongs;
    private ToolStripSpringTextBox tstbSongFilter;
    private ToolStripButton tsbModeOneSaber;
    private ToolStripButton tsbModeStandard;
    private ToolStripButton tsbModeNoArrows;
    private ToolStripButton tsbMode90;
    private ToolStripButton tsbMode360;
    private ToolStripButton tsbEntryClear;
    private ToolStripButton tsbEntryRemove;
    private ToolStripButton tsbEntryLast;
    private ToolStripButton tsbEntryFirst;
    private ToolStripButton tsbEntryDown;
    private ToolStripButton tsbEntryUp;
    private ToolStripButton tsbPlaylistSave;
    private ToolStripButton tsbPlaylistReread;
    private ToolStripButton tsbBeatsaberSetPath;
    private ToolStripButton tsbBeatsaberRefresh;
  }
}