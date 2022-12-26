using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }
     public void Exit()
    {
        Application.Quit();
    }

    public void FinishGame()
    {
        SceneManager.LoadScene("StartGame");
    }
}
