using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MenuUIHandler : MonoBehaviour
{

    public TMP_InputField userName;

    public void StartGame()
    {
        SetPlayerName();
        SceneManager.LoadScene(1);

    }

    private void SetPlayerName()
    {
        PlayerDataHandler.Instance.PlayerName = userName.textComponent.text;
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
