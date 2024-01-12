using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Managers
{
    private void Awake()
    {
        Init();
    }
    private void Start()
    {
        OnStageStart += SetHUD;
    }

    public void SetHUD()
    {
        //hud 리소스 로드 및 UI생성
    }
}