using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    private void Awake()
    {
        if (Time.timeScale != 1.0f)
        {
            Time.timeScale = 1.0f;
        }
    }

    public void OnClickStartButton()
    {
        SceneManager.LoadScene("02_MainGame");
    }

    public void OnClickQuitButton()
    {
        Application.Quit();
    }
}