using BeatSaber_Playlist_Editor.ViewModel;

namespace BeatSaber_Playlist_Editor {
  internal static class Program {
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main() {

      // To customize application configuration such as set high DPI settings or default font,
      // see https://aka.ms/applicationconfiguration.
      ApplicationConfiguration.Initialize();
      var view = new MainForm();
      view.Bind(new UIMain {
        IsStandardGameModeVisible = true,
      });
      Application.Run(view);
    }
  }
}