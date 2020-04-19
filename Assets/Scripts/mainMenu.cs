using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{

    public PlayerInfo player1Info;
    public PlayerInfo player2Info;

    public void PlayGame()
    {

        Debug.Log("button start clicked");

        player1Info.spawnPos = Vector2.zero;
        player2Info.spawnPos = new Vector2(-5.5f, -5.5f);
        player1Info.StoreToDisk();
        player2Info.StoreToDisk();

        SceneManager.LoadScene("IntroLevel");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
