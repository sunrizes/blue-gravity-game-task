using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("02_MainGame");
    }

    public void OnClickQuitButton()
    {
        Application.Quit();
    }
}