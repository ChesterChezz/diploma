using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{
    [SerializeField] GameObject mainMenuStage;
    [SerializeField] GameObject levelsStage;
    [SerializeField] List<Button> buttons;
    [SerializeField] Image red_btn;
   // public SqliteConnection dbconnection;
    private string path;
    private int count;

    private void FixedUpdate()
    {
       
        if (PlayerInfo.countLevels == 1)
        {
            buttons[2].interactable = false;
            buttons[1].interactable = false;
            buttons[3].interactable = false;
            buttons[4].interactable = false;
        }
        if (PlayerInfo.countLevels == 2)
        {
            buttons[1].interactable = true;
            buttons[2].interactable = false;
            buttons[3].interactable = false;
            buttons[4].interactable = false;
        }
        if (PlayerInfo.countLevels == 3)
        {
            buttons[2].interactable = true;
            buttons[1].interactable = true;
            buttons[3].interactable = false;
            buttons[4].interactable = false;
        }
        if (PlayerInfo.countLevels == 4)
        {
            buttons[2].interactable = true;
            buttons[1].interactable = true;
            buttons[3].interactable = true;
            buttons[4].interactable = false;
        }
        if (PlayerInfo.countLevels == 5)
        {
            buttons[2].interactable = true;
            buttons[1].interactable = true;
            buttons[3].interactable = true;
            buttons[4].interactable = true;
        }

    }
    public void Back_btn()
    {
        levelsStage.SetActive(false);
        mainMenuStage.SetActive(true);
    }
    public void Level1()
    {
        SceneManager.LoadScene("IntroScene");
    }
    public void Level2()
    {
        SceneManager.LoadScene("Level_1_2");
    }
    public void Level3()
    {
        SceneManager.LoadScene("Level_1_3");
    }
    public void Level4()
    {
        SceneManager.LoadScene("Level_1_4");
    }
    public void Level5()
    {
        SceneManager.LoadScene("Level_1_5");
    }

    // Update is called once per frame

}
