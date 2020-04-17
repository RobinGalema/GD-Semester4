using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{

    public void PlayGame()
    {

        Debug.Log("button start clicked");
        SceneManager.LoadScene("IntroLevel");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
