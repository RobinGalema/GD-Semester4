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
        if (buttonScript.isActivated && buttonPressed == false)
        {
            openDoor();
        }
        if (buttonScript.isActivated == false && buttonPressed)
        {
            closeDoor();
        }
    }

    private void openDoor()
    {
        Debug.Log("door should move");
        door.transform.position = (positionA + new Vector2(0,4));
        buttonPressed = true;
        Debug.Log("deeeeeurrr" + buttonPressed);

    }

    private void closeDoor()
    {
        door.transform.position = (positionA);
        buttonPressed = false;
    }
}
    

