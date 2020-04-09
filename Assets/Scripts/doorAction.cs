using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorAction : MonoBehaviour
{
    public List<button>  buttonScripts = new List<button>();
    public GameObject door;

    private Vector2 positionA;
    private bool wasActive = false;


    // Start is called before the first frame update
    void Start()
    {
        positionA = door.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (checkIfActive() && !wasActive)
        {
            openDoor();
            wasActive = true;
        }
        else if (!checkIfActive() && wasActive)
        {
            closeDoor();
            wasActive = false;
        }      
    }

    private void openDoor()
    {
        //moves door 4 increments upwards 
        door.transform.position = (positionA + new Vector2(0, 4));       
    }

    private void closeDoor()
    {
        //moves door to original position
        door.transform.position = (positionA); 
    }

    private bool checkIfActive()
    {
        foreach(var button in buttonScripts)
        {
            if (button.isActivated)
            {
                return true;
            }
        }
        return false;
    }
}


