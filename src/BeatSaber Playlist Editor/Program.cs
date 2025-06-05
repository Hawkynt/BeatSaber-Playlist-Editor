using System;
using System.Windows.Forms;
using BeatSaber_Playlist_Editor.ViewModel;
using BeatSaber_Playlist_Editor;

internal class Program {

  [STAThread]
  public static void Main(string[] args) {
    var view = new MainForm();
    view.Bind(new UIMain {
      IsStandardGameModeVisible = true,
    });
    Application.Run(view);
  }
}

