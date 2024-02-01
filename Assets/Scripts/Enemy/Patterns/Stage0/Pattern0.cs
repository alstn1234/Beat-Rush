using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern0 : IPattern
{
    public override void SetPattern()
    {
        _pattern = CSVReader.Read("Tutorial/tutorial.csv");
        _noteSpeed = 6.666666f;
        _noteStartPos = new Vector3(-2, 0, 42.5f);
        _curPatternNum = 0;
        _curStage = 0;
    }

    public override void Feedback()
    {
        _startDelay = Managers.Game.StageStartDelay[0];
        base.Feedback();
    }

}
