using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorAction : MonoBehaviour
{
    public button buttonScript;

    public GameObject door;

    private bool buttonPressed = false;
    private Vector2 positionA;


    // Start is called before the first frame update
    void Start()
    {
        positionA = door.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //opens the door when the button is pressed
        if (buttonScript.isActivated && buttonPressed == false)
        {
            openDoor();
        }
        //closes door when moved off of button
        if (buttonScript.isActivated == false && buttonPressed)
        {
            closeDoor();
        }
    }

    private void openDoor()
    {
        //moves door 4 increments upwards 
        door.transform.position = (positionA + new Vector2(0, 4));
        //sets button pressed to true, because otherwise it will move upwards once per frame
        buttonPressed = true;
    }

    private void closeDoor()
    {
        //moves door to original position
        door.transform.position = (positionA);
        buttonPressed = false;
    }
}


