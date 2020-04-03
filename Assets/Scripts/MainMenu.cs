﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {

        Debug.Log("button start clicked");
        SceneManager.LoadScene("level1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
