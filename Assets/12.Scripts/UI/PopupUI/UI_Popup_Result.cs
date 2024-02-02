using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Popup_Result : MonoBehaviour
{
    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Managers.Game.GameType = GameType.Main;
    }

    private void Start()
    {
        if (Managers.Game.Score > Managers.Data.BestScore)
        {
            PlayerPrefs.SetInt("BestScore", Managers.Game.Score);
        }

        if (Managers.Player.IsDie() == true)
            transform.GetChild(0).transform.GetComponent<TextMeshProUGUI>().text = "패배...";
        else
            transform.GetChild(0).transform.GetComponent<TextMeshProUGUI>().text = "승리!";
        ClearResult();
    }
    public void LoadStage()
    {
        Managers.Game.Score = 0;
        Managers.Game.Combo = 0;
        Managers.Game.MaxCombo = 0;
        Managers.Game.InitJudge();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadLobby()
    {
        Managers.Game.InitJudge();
        SceneManager.LoadScene("Lobby");
    }

    private void ClearResult()
    {
        GameObject.Find("Score_Text").transform.GetComponent<TextMeshProUGUI>().text = Managers.Game.Score.ToString();
        GameObject.Find("Combo_Text").transform.GetComponent<TextMeshProUGUI>().text = Managers.Game.MaxCombo.ToString();
        GameObject.Find("Perfect_Text").transform.GetComponent<TextMeshProUGUI>().text = Managers.Game.judgeNotes[(int)Score.Perfect].ToString();
        GameObject.Find("Great_Text").transform.GetComponent<TextMeshProUGUI>().text = Managers.Game.judgeNotes[(int)Score.Great].ToString();
        GameObject.Find("Good_Text").transform.GetComponent<TextMeshProUGUI>().text = Managers.Game.judgeNotes[(int)Score.Good].ToString();
        GameObject.Find("Bad_Text").transform.GetComponent<TextMeshProUGUI>().text = Managers.Game.judgeNotes[(int)Score.Bad].ToString();
        GameObject.Find("Miss_Text").transform.GetComponent<TextMeshProUGUI>().text = Managers.Game.judgeNotes[(int)Score.Miss].ToString();
    }

    private void OnDisable()
    {
        Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}