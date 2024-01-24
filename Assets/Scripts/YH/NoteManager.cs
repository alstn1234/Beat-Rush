using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    private List<Dictionary<string, object>> _sheet;
    public IMonster monster;

    private ObjectPool _notePool;
    private float _noteSpeed;
    private float _startDelay = 0.3f;
    private double _curDsp;
    private double _startDsp;
    private double _pauseDsp;

    private int _feedbackCount = 0;

    private void Awake()
    {
        _sheet = CSVReader.Read("Assets/@Resources/Sheet1.csv");
    }

    private void Start()
    {
        Managers.Game.GameType = GameType.Play;
        _notePool = Managers.Pool;
        _notePool.SetPool();
        _noteSpeed = 5 / (60 / Managers.Game.bpm);
        _curDsp = AudioSettings.dspTime;

        StartCoroutine(CreateNewNotes());
    }

    private void Update()
    {
        if(Time.timeScale>0)
        {
            if (_feedbackCount > 12 && Managers.Sound.PlayTime() > 0)
            {
                FeedBack();
            }
            _feedbackCount++;
            MoveNotes();
        }
        else
        {
            _startDsp += AudioSettings.dspTime - _curDsp;
        }
        _curDsp = AudioSettings.dspTime;
    }

    private void MoveNotes()
    {
        float movement = ((float)(AudioSettings.dspTime - _curDsp) * _noteSpeed);
        foreach (GameObject note in Managers.Pool.GetActiveNotes())
        {
            note.gameObject.transform.position = new Vector3(note.gameObject.transform.position.x, note.gameObject.transform.position.y,
            note.gameObject.transform.position.z - movement);
        }
    }

    private IEnumerator CreateNewNotes()
    {
        float waitTime = 0;
        Managers.Sound.DelayedPlayBGM(BGM.Stage1,32.5f / _noteSpeed - _startDelay);
        _startDsp = AudioSettings.dspTime;

        for (int i = 0; i < _sheet.Count - 1; i++)
        {
            waitTime = (float)_sheet[i + 1]["noteLocation"] - (float)_sheet[i]["noteLocation"];
            GameObject note = _notePool.SpawnFromPool();
            note.transform.position = new Vector3((float)_sheet[i]["xValue"] + 40, 4, 42.5f);
            yield return new WaitForSeconds(waitTime / _noteSpeed);
        }
        StartCoroutine(Managers.Sound.VolumeDown());
    }

    private void FeedBack()
    {
        List<GameObject> _activeNotes = Managers.Pool.GetActiveAliveNotes();
        float _noteDistance = _noteSpeed * ((float)(AudioSettings.dspTime - _startDsp) - _startDelay);

        int cnt = 0;
        for(int i = Managers.Game.curNote; i<_activeNotes.Count;i++)
        {
            float curLocation = (float)_sheet[i]["noteLocation"] - _noteDistance;
            if (curLocation >= 0 && curLocation <= 32.5)
            {
                GameObject note = cnt < _activeNotes.Count ? _activeNotes[cnt] : _notePool.SpawnFromPool();
                note.transform.position = new Vector3(note.transform.position.x, note.transform.position.y, curLocation + 10);
                cnt++;

            }
            else if(curLocation >32.5) break;
        }
    }
}
