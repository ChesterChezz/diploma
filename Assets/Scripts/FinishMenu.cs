using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishMenu : MonoBehaviour
{

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void NextLevel()
    {
        Debug.Log("AZA");
        Time.timeScale = 1f;
        string sceneName = SceneManager.GetActiveScene().name;
        char x = sceneName[sceneName.Length - 1];
        int z = (int)(x - '0');
        z++;
        sceneName = sceneName.Substring(0, sceneName.Length - 1);
        sceneName += z.ToString();
        Debug.Log(sceneName);
        SceneManager.LoadScene(sceneName);
    }
    

}
