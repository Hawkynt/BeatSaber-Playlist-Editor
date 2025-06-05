using System.Collections.Generic;
using System.Drawing;

namespace BeatSaberAPI;

public interface ISong { 
  string Title { get;}
  string? Artist { get; }
  string? LevelAuthor { get; }
  double BeatsPerMinute { get; }
  string? Environment { get; }
  GameMode SupportedGameModes { get; }
  IReadOnlyDictionary<GameMode, DifficultyMode> Difficulties { get; }
  Image? Image { get; }
  string CalculateChecksum();
}

