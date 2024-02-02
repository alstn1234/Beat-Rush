using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class UI_Popup_Option : MonoBehaviour
{
    private void OnEnable()
    {
        Managers.Game.LobbyPopupCount++;

        //Time.timeScale = 0.0f;
        //Cursor.lockState = CursorLockMode.None;
        //Managers.Game.lockType = InputLockType.Lock;
        //Cursor.visible = true;

    }
    private void Update()
    {
        //옵션 창 닫는 부분은 나중에 Input System으로 처리해도 될 것 같습니다.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OffOption();
        }
    }
    public void OnLobby()
    {
        OffOption();
        if (SceneManager.GetActiveScene().name == "Lobby")
            return;
        Managers.Sound.StopBGM();
        Managers.Sound.LoopPlayBGM(BGM.Lobby2);
        SceneManager.LoadScene("Lobby");
    }
    public void OffOption()
    {
        gameObject.SetActive(false);
        Managers.Sound.ContinueBGM();        //음악 재생

        Managers.Game.LobbyPopupCount--;
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
        //Time.timeScale = 1.0f;
        //Managers.Game.lockType = InputLockType.UnLock;
    }
}