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
        while(_curBar < _sheet1.Length)
        {
            _bar = Instantiate(_sheet1[_curBar]);
            _bar.transform.position = new Vector3(- 2, 0, 42.5f);
            _curBar++;
            yield return new WaitForSecondsRealtime(6.666f);        //�� ���� ��Ʈ 8�� X 1���� �ð� = 60 / 72(bpm) 
        }

        yield return new WaitForSecondsRealtime(6.666f);
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
