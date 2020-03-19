using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiController : MonoBehaviour
{
    public controllerAssigner controllerManager;
    public GameObject[] startingText;

    private int numberOfPlayers;

    // Start is called before the first frame update
    void Start()
    {
        setup();
    }

    // Update is called once per frame
    void Update()
    {
        if (!controllerManager.controller1Assigned)
        {
            displayStartText(true, 0);
        }
        else if(controllerManager.controller1Assigned && !controllerManager.controller2Assigned && numberOfPlayers == 2)
        {
            displayStartText(true, 1);
        }
        else
        {
            displayStartText(false);
        }
    }

    private void setup()
    {
        if (controllerManager.player1Control != null && controllerManager.player2Control != null)
        {
            numberOfPlayers = 2;
        }
        else if (controllerManager.player1Control != null || controllerManager.player2Control != null)
        {
            numberOfPlayers = 1;
        }
        else
        {
            numberOfPlayers = 0;
        }
    }

    private void displayStartText(bool shouldDisplay, int id = 0)
    {
        if (shouldDisplay)
        {
            for (int i = 0; i < startingText.Length; i++)
            {
                if (i == id)
                {
                    startingText[i].SetActive(true);
                }
                else
                {
                    startingText[i].SetActive(false);
                }
            }
        }
        else
        {
            foreach (var item in startingText)
            {
                item.SetActive(false);
            }
        }
    }
}
