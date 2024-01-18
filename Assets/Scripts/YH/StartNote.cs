using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartNote : Note
{
    //TODO: ��Ʈ �Ŵ����� �����ؼ� ���� ����ϰ� ����
    [SerializeField] private SoundManager _soundManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Line"))
        {
            
            Destroy(gameObject);
        }
    }
}
