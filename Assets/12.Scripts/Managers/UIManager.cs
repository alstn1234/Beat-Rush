using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements.Experimental;

public class UIManager : MonoBehaviour
{
    public void SetUI()
    {
        if (SceneManager.GetActiveScene().name == "StartUI_Test_Scene")
        {
            SetStartHUD();
        }
        else if (SceneManager.GetActiveScene().name == "StageUI_Test_Scene" || SceneManager.GetActiveScene().name == "Stage_1" || SceneManager.GetActiveScene().name == "Stage_2")
        {
            SetStageHUD();
        }
        else if (SceneManager.GetActiveScene().name == "LobbyUI_Test_Scene" || SceneManager.GetActiveScene().name == "Lobby")
        {
            SetMapHUD();
        }
        else if(SceneManager.GetActiveScene().name == "Tutorial")
        {
            SetTutorialHUD();
        }
    }

    private void SetStageHUD()
    {
        Instantiate(Managers.Resource.Load<GameObject>($"UI_Stage.prefab"));
    }
    private void SetStartHUD()
    {
        Instantiate(Managers.Resource.Load<GameObject>($"UI_Start.prefab"));
    }
    private void SetMapHUD()
    {
        Instantiate(Managers.Resource.Load<GameObject>($"UI_Lobby.prefab"));
    }
    private void SetTutorialHUD()
    {
        Instantiate(Managers.Resource.Load<GameObject>($"UI_Tutorial.prefab"));
    }
}