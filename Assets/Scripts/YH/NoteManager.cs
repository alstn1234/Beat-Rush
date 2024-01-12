using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    private GameObject[] _sheet1;
    private int _curBar = 1;
    private GameObject _bar;
    public AudioSource music1;          //TODO : ���߿� private���� �ٲٰ� �Ŵ����� ���� ������ ����.

    [Range(0f, 5f)]
    public float latency = 0f;
    [Range(0f, 0.2f)]
    public float instantiateDelay = 0.085f;
    private float _bpm = 72;


    private void Awake()
    {
        _sheet1 = Resources.LoadAll<GameObject>("Sheet1");
    }

    private void Start()
    {
        StartCoroutine(CreateNote());
    }

    private IEnumerator CreateNote()
    {
        while (_curBar < _sheet1.Length)
        {
            _bar = Instantiate(_sheet1[_curBar]);
            _bar.transform.position = new Vector3(-2, 0, 40f + latency);
            _curBar++;
            yield return new WaitForSecondsRealtime((float)(8 * 60 / _bpm) - instantiateDelay);        //�� ���� ��Ʈ 8�� X 1���� �ð� = 60 / 72(bpm) - �ν��Ͻ� ������(����)
        }

        yield return new WaitForSecondsRealtime(6.66f);
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
}
