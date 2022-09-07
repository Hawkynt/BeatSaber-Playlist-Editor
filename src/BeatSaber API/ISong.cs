using System.Drawing;

namespace BeatSaberAPI;

public interface ISong { 
  string Title { get;}
  string? Artist { get; }
  GameMode SupportedGameModes { get; }
  IReadOnlyDictionary<GameMode, DifficultyMode> Difficulties { get; }
  Image? Image { get; }
  string CalculateChecksum();
}

