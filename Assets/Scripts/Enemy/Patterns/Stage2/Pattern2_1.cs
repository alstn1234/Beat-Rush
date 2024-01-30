using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern2_1 : IPattern
{
    private List<Dictionary<string, object>> _pattern;
    private double _startDsp;
    private float _startDelay = 0.3f;
    private float _noteSpeed = 13.2f;
    public bool _isFeedbackStart;

    public void SetPattern()
    {
        _pattern = CSVReader.Read("Stage2/pattern1.csv");
    }

    public IEnumerator Attack()
    {
        float waitTime = 0;

        for (int i = 0; i < _pattern.Count - 1; i++)
        {
            waitTime = (float)_pattern[i + 1]["noteLocation"] - (float)_pattern[i]["noteLocation"];
            GameObject note = Managers.Pool.SpawnFromPool();
            note.transform.position = new Vector3((float)_pattern[i]["xValue"] - 2, 2, 42.5f+Managers.Game.delay);
            yield return new WaitForSeconds(waitTime / _noteSpeed);
        }
    }

    public void Feedback()
    {
        if (!_isFeedbackStart)
        {
            _startDsp = AudioSettings.dspTime;
            _isFeedbackStart = true;
        }

        List<GameObject> _activeNotes = Managers.Pool.GetActiveAliveNotes();
        float _noteDistance = _noteSpeed * (float)(AudioSettings.dspTime - _startDsp) + _startDelay;

        int cnt = 0;
        for (int i = Managers.Game.curNote; i < Managers.Game.curNote + _activeNotes.Count; i++)
        {
            float curLocation = (float)_pattern[i]["noteLocation"] - _noteDistance;
            GameObject note = _activeNotes[cnt++];
            note.transform.position = new Vector3(note.transform.position.x, note.transform.position.y, curLocation + 42.5f + Managers.Game.delay);
        }
    }

    public void Pause()
    {
        _isFeedbackStart = false;
    }
}