namespace BeatSaberAPI.BeatSaberInstallation {
  [Flags]
  public enum DifficultyMode {
    Easy=1,
    Normal=1<<1,
    Hard=1<<2,
    Expert=1<<3,
    ExpertPlus=1<<4,
  }

}
