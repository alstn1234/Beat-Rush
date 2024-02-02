using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Popup_Quest : MonoBehaviour
{
    private void OnEnable()
    {
        Managers.Game.LobbyPopupCount++;

        //Time.timeScale = 0.0f;
        //Cursor.lockState = CursorLockMode.None;
        //Managers.Game.lockType = InputLockType.Lock;
        //Cursor.visible = true;
    }

    public void closeWindow()
    {
        gameObject.SetActive(false);

        Managers.Game.LobbyPopupCount--;

        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
        //Time.timeScale = 1.0f;
        //Managers.Game.lockType = InputLockType.UnLock;
    }
}