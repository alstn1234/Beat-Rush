using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private void Start()
    {
        Managers.Game.OnStageStart += SetHUD;
    }

    public void SetHUD()
    {
        //hud ���ҽ� �ε� �� UI����
    }
}