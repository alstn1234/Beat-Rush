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
        //gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material.color = Color.red;
    }

    private void Update()
    {
        // ��ģ ��Ʈ �ı�
        if (transform.position.z < -15)
        {
            BreakNote();
            // TODO : �÷��̾� �ǰ� ����
        }
        else
        {
            // ��Ʈ �̵�
            transform.position = new Vector3(transform.position.x, transform.position.y,
            transform.position.z - ((float)(AudioSettings.dspTime - _curDsp) * _noteSpeed));
            _curDsp = AudioSettings.dspTime;

            //��Ʈ Ÿ�̹� ����ȭ
            //if (transform.position.z < 4 && transform.position.z > 0)
            //{
            //    if(GetComponent<MeshRenderer>()==null)
            //    {
            //        _curColor = gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material.color;
            //        gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material.color = Color.Lerp(_curColor, Color.red, 4f * Time.deltaTime);
            //    }
            //}
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
