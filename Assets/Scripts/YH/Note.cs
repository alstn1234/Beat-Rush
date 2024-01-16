using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    private ParticleSystem _particle;
    private float _noteDistance = 5;
    // TODO : �Ŵ��� ����� bpm�� �ű⼭ �������� �ɷ�.
    private float _musicBpm = 72;
    private float _noteSpeed;
    private double _curDsp;
    private Color _curColor;
    protected void Awake()
    {
        _particle = Resources.Load<ParticleSystem>("Blood Splash");
    }

    private void Start()
    {
        _particle.Stop();
        _noteSpeed = _noteDistance / (60 / _musicBpm);
        _curDsp = AudioSettings.dspTime;
    }

    private void Update()
    {
        // ��ģ ��Ʈ �ı�
        if (gameObject.transform.position.z < 8)
        {
            Managers.Game.Combo = 0;
            BreakNote();
            // TODO : �÷��̾� �ǰ� ����
        }
        else
        {
            // ��Ʈ �̵�
            transform.position = new Vector3(transform.position.x, transform.position.y,
            transform.position.z - ((float)(AudioSettings.dspTime - _curDsp) * _noteSpeed));
            _curDsp = AudioSettings.dspTime;
        }
    }

    private void OnEnable()
    {
        _curDsp = AudioSettings.dspTime;
    }

    public void BreakNote()
    {
        ParticleSystem _destroyParticle = Instantiate(_particle);
        _destroyParticle.transform.position = transform.position;
        _particle.Play();
        transform.position = Vector3.zero;
        gameObject.SetActive(false);
    }
}
