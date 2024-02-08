using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern2_6 : IPattern
{
    public override void SetPattern()
    {
        _pattern = CSVReader.Read("Stage2/pattern6.csv");
        _stageNoteSpeed = Managers.Game.noteSpeed[Managers.Game.currentStage] * Managers.Game.speedModifier;
        _noteStartPos = Managers.Game.StageNotePos[2];
        _curPatternNum = 6;
        _curStage = 2;
    }

    public override void Feedback()
    {
        _startDelay = Managers.Game.StageStartDelay[2];
        base.Feedback();
    }
}
