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

    var screenshotIndex = Array.IndexOf(args, SCREENSHOT_ARGUMENT);
    var screenshotPath = screenshotIndex >= 0
      ? screenshotIndex + 1 < args.Length ? args[screenshotIndex + 1] : "screenshot.png"
      : null;
    var tracePath = screenshotPath == null ? null : Path.GetFullPath(screenshotPath) + ".trace";
    if (tracePath != null) {
      Directory.CreateDirectory(Path.GetDirectoryName(tracePath)!);
      File.WriteAllText(tracePath, "initialized" + Environment.NewLine);
    }

    UIMain viewModel = new() { IsStandardGameModeVisible = true };
    if (screenshotIndex >= 0) {
      viewModel.SetInstallation(ScreenshotSampleData.CreateInstallation());
      viewModel.SetCurrentPlaylist(viewModel.Playlists[0]);
      viewModel.CurrentSong = viewModel.Songs[0];
      _Trace(tracePath!, "sample-data-bound");
    }

    using MainForm view = new();
    _Trace(tracePath, "form-created");
    view.Bind(viewModel);
    _Trace(tracePath, "form-bound");

    if (screenshotPath != null) {
      _CaptureScreenshot(view, screenshotPath, tracePath!);
      Environment.Exit(0);
      return;
    }

    Application.Run(view);
  }

  private static void _CaptureScreenshot(MainForm view, string outputPath, string tracePath) {
    _Trace(tracePath, "capture-start");
    view.StartPosition = FormStartPosition.Manual;
    view.Location = Point.Empty;
    view.Size = new Size(1280, 720);
    _Trace(tracePath, "before-show");
    view.Show();
    _Trace(tracePath, "after-show");
    view.PerformLayout();
    _Trace(tracePath, "after-layout");
    view.Refresh();
    _Trace(tracePath, "after-refresh");

    using Bitmap screenshot = new(view.ClientSize.Width, view.ClientSize.Height);
    _Trace(tracePath, "before-draw");
    view.DrawToBitmap(screenshot, new Rectangle(Point.Empty, view.ClientSize));
    _Trace(tracePath, "after-draw");

    var fullPath = Path.GetFullPath(outputPath);
    Directory.CreateDirectory(Path.GetDirectoryName(fullPath)!);
    screenshot.Save(fullPath, ImageFormat.Png);
    _Trace(tracePath, "saved");
  }

  private static void _Trace(string? path, string message) {
    if (path != null)
      File.AppendAllText(path, message + Environment.NewLine);
  }

}
