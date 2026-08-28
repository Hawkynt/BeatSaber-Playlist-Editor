using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using BeatSaber_Playlist_Editor;
using BeatSaber_Playlist_Editor.ViewModel;

internal static class Program {

  private const string SCREENSHOT_ARGUMENT = "--screenshot";

  [STAThread]
  public static void Main(string[] args) {
    ApplicationConfiguration.Initialize();

    using MainForm view = new();
    view.Bind(new UIMain { IsStandardGameModeVisible = true });

    var screenshotIndex = Array.IndexOf(args, SCREENSHOT_ARGUMENT);
    if (screenshotIndex >= 0) {
      var outputPath = screenshotIndex + 1 < args.Length ? args[screenshotIndex + 1] : "screenshot.png";
      _CaptureScreenshot(view, outputPath);
      return;
    }

    Application.Run(view);
  }

  private static void _CaptureScreenshot(MainForm view, string outputPath) {
    view.StartPosition = FormStartPosition.Manual;
    view.Location = Point.Empty;
    view.Size = new Size(1280, 720);
    view.Show();
    Application.DoEvents();
    view.Refresh();
    Application.DoEvents();

    using Bitmap screenshot = new(view.ClientSize.Width, view.ClientSize.Height);
    view.DrawToBitmap(screenshot, new Rectangle(Point.Empty, view.ClientSize));

    var fullPath = Path.GetFullPath(outputPath);
    Directory.CreateDirectory(Path.GetDirectoryName(fullPath)!);
    screenshot.Save(fullPath, ImageFormat.Png);
    view.Close();
  }

}
