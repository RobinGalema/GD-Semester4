using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllerAssigner : MonoBehaviour
{
    public playerMovement player1Control;
    public playerMovement player2Control;

    private bool allPlayersAssigned;

    private void Start()
    {
        allPlayersAssigned = false;
    }

    void Update()
    {
        if (!allPlayersAssigned)
        {
            for (int i = 1; i <= 2; i++)
            {
                if (Input.GetButtonDown("A" + i + "PS4"))
                {
                    Debug.Log("PS4 Controller set-up with controller index: " + i);
                    assignController(i + "PS4");
                    break;
                }
            }

            for (int i = 1; i <= 2; i++)
            {
                if (Input.GetButtonDown("A" + i + "XBOX"))
                {

                    Debug.Log("XBOX Controller set-up with controller index" + i);
                    assignController(i + "XBOX");
                    break;
                }
            }
        }
    }

    private void assignController(string controllerSuffix)
    {
        //Debug.Log(player1Control.controllerSuffix);
        if (player1Control.controllerSuffix == "")
        {
            player1Control.controllerSuffix = controllerSuffix;
            Debug.Log(player1Control.controllerSuffix);
            return;
        }
        else if (player1Control.controllerSuffix == controllerSuffix)
        {
            Debug.LogError("This controller is already assigned");
            return;
        }
        else if (player2Control.controllerSuffix == "")
        {
            player2Control.controllerSuffix = controllerSuffix;
            Debug.Log(player2Control.controllerSuffix);
        }
        else
        {
            Debug.LogError("All players already have a controller assigned to them");
            allPlayersAssigned = true;
        }

    }
}
