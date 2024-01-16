using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public LayerMask noteLayer;

    [SerializeField]
    private Player player;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Z))
        {
            CheckNotes();
        }
    }

    private void CheckNotes()
    {
        Collider[] colliders = Physics.OverlapBox(transform.position, new Vector3(10, 5, 0.01f) / 2, Quaternion.identity, noteLayer);
        if (colliders.Length > 0)
        {
            player.Rotate(colliders[0].transform);
            float distance = Mathf.Abs(transform.position.z - colliders[0].transform.position.z);
            colliders[0].GetComponent<Note>().BreakNote();
            Managers.Game.Combo++;
            Managers.Game.AddScore((distance < 0.4 ? 50 : 30) + Managers.Game.Combo);     //������ ���� ���� �ٸ�
            if(player.CurrentStateData.SkillGauge < 100.0f)
                player.CurrentStateData.SkillGauge += 10;
            Debug.Log(Managers.Game.Combo + " " + Managers.Game.Score);
        }
    }
}
