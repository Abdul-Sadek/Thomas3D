using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    PlayerData playerData;
    void Start()
    {
        playerData = new PlayerData();
    }

    public void load_levels()
    {
        if(playerData.levels == 1)
        {
            Debug.Log(playerData.levels);
            SceneManager.LoadScene("Level2");
        }
        else if (playerData.levels == 2)
        {
            SceneManager.LoadScene("Level3");
        }
        else if (playerData.levels == 3)
        {
            SceneManager.LoadScene("Win_Screen");
        }
    }
    public void start_game()
    {
        SceneManager.LoadScene("Level1");
    }
    public void exit_game()
    {
        Application.Quit();
    }
}
