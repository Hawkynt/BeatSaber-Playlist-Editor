namespace BeatSaberAPI;

public interface ISong { 
  string Title { get;}
  string? Artist { get; }
  GameMode SupportedGameModes { get; }
  IReadOnlyDictionary<GameMode, DifficultyMode> Difficulties { get; }

  string CalculateChecksum();
}

