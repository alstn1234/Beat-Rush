using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    private List<Dictionary<string, object>> _sheet;
    private int _curBar = 1;
    public AudioSource music1;          //TODO : ���߿� private���� �ٲٰ� �Ŵ����� ���� ������ ����.
    private ObjectPool _notePool;         

    [Range(0f, 5f)]
    public float latency = 0f;
    [Range(0f, 0.2f)]
    public float instantiateDelay = 0f;
    private float _bpm = 72;


    private void Awake()
    {
        _sheet = CSVReader.Read("test");
        _notePool = Managers.Pool;
    }

    private void Start()
    {
        _notePool.SetPool();
        StartCoroutine(CreateNote());
    }

    private IEnumerator CreateNote()
    {
        while (_curBar < 18)
        {
            SetNotes(_curBar);
            _curBar++;
            yield return new WaitForSeconds((float)(8 * 60 / _bpm) - instantiateDelay);        //�� ���� ��Ʈ 8�� X 1���� �ð� = 60 / 72(bpm) - �ν��Ͻ� ������(����)
        }

        yield return new WaitForSeconds(6.66f);
        StartCoroutine(VolumeDown());       //�������� ������ ���� �ٿ�
    }

    private IEnumerator VolumeDown()
    {
        while (music1.volume > 0)
        {
            music1.volume -= Time.deltaTime / 4;        // 4�ʿ� ���� �پ�鵵��
            Debug.Log("Volume Down");
            yield return null;
        }
        //TODO : �������� ���� �׼� �ݹ�
    }

    private void SetNotes(int current)
    {
        for (int i = 0; i < _sheet.Count; i++)
        {
            if ((int)_sheet[i]["curBar"] == current)
            {
                GameObject note = _notePool.SpawnFromPool();
                float xPos = (float)_sheet[i]["xValue"];
                float zPos = (float)_sheet[i]["zValue"];
                //note.GetComponentInChildren<SkinnedMeshRenderer>().material.color = Color.black;

                note.transform.position = new Vector3(xPos - 2, 1, zPos + 42.5f);
            }
        }
    }
}
