global using BeatSaber_Playlist_Editor.ViewModel;

[STAThread]
ApplicationConfiguration.Initialize();
var view = new MainForm();
view.Bind(new UIMain
{
    IsStandardGameModeVisible = true,
});
Application.Run(view);

