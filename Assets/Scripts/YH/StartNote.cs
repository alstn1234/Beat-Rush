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
            //_music.PlayDelayed(20 * (60 / Managers.Game.bpm) / 5 +1.6f);  // ��Ʈ���� �Ÿ� 20 * 1m �� �ӵ�
            _soundManager.PlayClip(20 * (60 / Managers.Game.bpm) / 5 + 1.6f);
            Destroy(gameObject);
        }
    }
}
