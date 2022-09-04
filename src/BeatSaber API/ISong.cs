namespace BeatSaberAPI;

public interface ISong { 
  string Title { get;}
  string? Artist { get; }

  string CalculateChecksum();
}

