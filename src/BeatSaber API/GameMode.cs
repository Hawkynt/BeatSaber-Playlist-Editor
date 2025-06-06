﻿using System;

namespace BeatSaberAPI;

[Flags]
public enum GameMode {
  Normal = 1,
  OneSaber = 1 << 1,
  NoArrows = 1 << 2,
  NinetyDegrees = 1 << 3,
  ThreeSixtyDegrees = 1 << 4,
}
