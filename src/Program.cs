namespace BeatSaber_Playlist_Editor
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            var bs = BeatSaberInstallation.BeatSaber.FromGameDirectory(new DirectoryInfo(@"V:\Games\Beat Saber"));
      
            var songs = bs.Songs.ToArray();
            var firstSong=songs.FirstOrDefault();
            var songTitle = firstSong?.Title;

            var lists = bs.Playlists.ToArray();
            var firstList = lists.FirstOrDefault();
            var listName=firstList?.Name;


            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}