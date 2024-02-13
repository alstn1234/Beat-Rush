using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Popup_Tutorial : MonoBehaviour
{
    private void Start()
    {
        Managers.Game.IsLobbyPopup = true;
        Managers.Sound.StopBGM();
    }

    private void OnDisable()
    {
        Managers.Game.IsLobbyPopup = false;
        Managers.Sound.DelayedPlayBGM(0, 32.5f / (Managers.Game.noteSpeed[0] * Managers.Game.speedModifier));        //음악 재생
    }
}