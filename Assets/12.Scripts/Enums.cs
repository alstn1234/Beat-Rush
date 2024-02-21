

public enum GameType
{
    Lobby,
    Play
}

public enum InputLockType
{
    Lock,
    UnLock,
}

public enum Score
{
    Perfect,
    Great,
    Good,
    Bad,
    Miss
}

public enum QuestReward
{
    HealthUp = 0,
    SkillGaugIncrementUp,
    SkillSpeedDown,
    SkillExtendedDistance,
    SpeedUp,
}

public enum QuestName
{
    TutorialComplete = 0,
    StageFirstComplete,
    Stage100Combo,
    MaxHealthClear,
    SpeedUpClear,
    SuddenModeClear,
    PlayTime,
    NoSkillStageClear,
    SRankClear,
}

public enum Rank
{
    S = 0,
    A,
    B,
    C,
    F,
}

public enum GameMode
{
    normal,
    Sudden
}