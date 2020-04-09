using UnityEngine;

public class controllerAssigner : MonoBehaviour
{
    public playerMovement player1Control;
    public playerMovement player2Control;
    public PlayerInfo player1Info;
    public PlayerInfo player2Info;

    [HideInInspector] public bool controller1Assigned;
    [HideInInspector] public bool controller2Assigned;
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
                    Debug.Log("Trying to set up PS4 Controller with controller index: " + i);
                    assignController(i + "PS4", i);
                    break;
                }
            }

            for (int i = 1; i <= 2; i++)
            {
                if (Input.GetButtonDown("A" + i + "XBOX"))
                {

                    Debug.Log("Trying to set-up XBOX Controller with controller index" + i);
                    assignController(i + "XBOX", i);
                    break;
                }
            }
        }
    }

    private void assignController(string controllerSuffix, int controllerNumber)    // Can be written better
    {
        if (player1Control.controllerSuffix == "")
        {
            if (!controller1Assigned)
            {
                player1Control.controllerSuffix = controllerSuffix;
                Debug.Log(player1Control.controllerSuffix);

                assignControllers(controllerNumber);
                player1Control.controllerNumber = controllerNumber;
                Debug.Log("controller 1 assigned -> "+ controllerNumber);
            }
            else if (!controller2Assigned)
            {
                player1Control.controllerSuffix = controllerSuffix;
                Debug.Log(player1Control.controllerSuffix);

                assignControllers(controllerNumber);
                player1Control.controllerNumber = controllerNumber;
                Debug.Log("controller 2 assigned -> " + controllerNumber);
            }
            player1Info.controllerSuffix = controllerSuffix;

        }
        else if (player1Control.controllerNumber == controllerNumber)
        {
            Debug.LogError("This controller is already assigned");
            return;
        }
        else if (player2Control.controllerSuffix == "")
        {
            if (!controller1Assigned)
            {
                player2Control.controllerSuffix = controllerSuffix;
                Debug.Log(player2Control.controllerSuffix);

                assignControllers(controllerNumber);
                player2Control.controllerNumber = controllerNumber;
                Debug.Log("controller 1 assigned -> " + controllerNumber);

            }
            else if(!controller2Assigned)
            {
                player2Control.controllerSuffix = controllerSuffix;
                Debug.Log(player2Control.controllerSuffix);

                assignControllers(controllerNumber);
                player2Control.controllerNumber = controllerNumber;
                Debug.Log("controller 2 assigned -> " + controllerNumber);

            }
            player2Control.controllerSuffix = controllerSuffix;
        }
        else
        {
            Debug.LogError("All players already have a controller assigned to them");
            allPlayersAssigned = true;
        }

    }

    private void assignControllers(int controllerNumber)
    {
        if (controllerNumber == 1)
        {
            controller1Assigned = true;
        }
        else if (controllerNumber == 2)
        {
            controller2Assigned = true;
        }
        else
            return;
    }
}
