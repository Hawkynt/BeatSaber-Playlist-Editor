namespace BeatSaber_Playlist_Editor {
  internal static class Program {
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main() {

      var bs = BeatSaberInstallation.BeatSaber.FromGameDirectory(new DirectoryInfo(@"V:\Games\Beat Saber"));

      var songs = bs.Songs.ToArray();
      var firstSong = songs.FirstOrDefault(s => s.Title.Contains("Storm"));
      var songTitle = firstSong?.Title;
      var sha1 =firstSong?.CalculateChecksum();

      var lists = bs.Playlists.ToArray();
      var firstList = lists.FirstOrDefault();
      var listName = firstList?.Name;

      var allSha1 = (
        from song in songs
        let sha = song.CalculateChecksum()
        group song by sha into checksums
        select checksums
      ).ToDictionary(g => g.Key, g => g.ToArray(),StringComparer.OrdinalIgnoreCase);

      var duplicates = allSha1.Where(kvp => kvp.Value.Length > 1).ToArray();

      var songsInList = firstList?.Songs.Select(s=>allSha1.TryGetValue(s.Sha1Hash,out var i) ? (s, i[0]):(s,null)).ToArray();
      for(var i = 0; i < songsInList.Length; ++i) {
        var song = songsInList[i];
        if (song.Item2 == null)
          continue;

        firstList.Songs.RemoveAt(i);
        firstList.Songs.InsertAt(i, firstList.CreateEntry(song.Item2));
      }
      firstList.WriteToDisk();

      var testList = lists.FirstOrDefault(i => i.Name == "test");
      if (testList != null)
        bs.Playlists.Delete("test");
      
      testList = bs.Playlists.Create("test");
      testList.WriteToDisk();


      // To customize application configuration such as set high DPI settings or default font,
      // see https://aka.ms/applicationconfiguration.
      ApplicationConfiguration.Initialize();
      Application.Run(new MainForm());
    }
  }
}