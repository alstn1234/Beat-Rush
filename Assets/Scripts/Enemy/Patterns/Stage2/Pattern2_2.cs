using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern2_2 : IPattern
{
    public override void SetPattern()
    {
        _pattern = CSVReader.Read("Stage2/pattern2.csv");
        _noteSpeed = 13.2f;
        _noteStartPos = new Vector3(-2, 2, 42.5f);
        _curPatternNum = 2;
        _curStage = 2;
    }

    public override void Feedback()
    {
        _startDelay = Managers.Game.StageStartDelay[2];
        base.Feedback();
    }
}
