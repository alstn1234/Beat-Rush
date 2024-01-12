using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartNote : Note
{
    //TODO: ��Ʈ �Ŵ����� �����ؼ� ���� ����ϰ� ����
    [SerializeField] private AudioSource _music;
    private float _bpm = 72;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Line"))
        {
            _music.PlayDelayed(20 * (60 / _bpm) / 5);  // ��Ʈ���� �Ÿ� 20 * 1m �� �ӵ�
            Destroy(gameObject);
        }
    }
}
