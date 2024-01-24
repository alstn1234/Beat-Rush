using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    private ParticleSystem _particle;

    protected void Awake()
    {
        _particle = Resources.Load<ParticleSystem>("Blood Splash");
    }

    private void Start()
    {
        _particle.Stop();
    }

    private void Update()
    {
        if (gameObject.transform.position.z < 8 && Time.timeScale > 0)
        {
            Managers.Game.Combo = 0;
            BreakNote();
            Managers.Player.ChangeHealth(-1);
            Managers.Game.judgeNotes[(int)Score.Miss]++;
        }
    }

    public void BreakNote()
    {
        ParticleSystem _destroyParticle = Instantiate(_particle);
        _destroyParticle.transform.position = transform.position;
        _particle.Play();
        transform.position = Vector3.zero;
        Managers.Game.curNote++;
        gameObject.SetActive(false);
    }
}
