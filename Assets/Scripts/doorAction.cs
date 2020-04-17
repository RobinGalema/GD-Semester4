﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorAction : MonoBehaviour
{
    public List<button>  buttonScripts = new List<button>();
    public GameObject door;
    public float moveX = 0f;
    public float moveY = 0f;
    public float rotation = 0;
    public lever leverScript;

    private Quaternion standardRotation;
    private Vector2 positionA;
    private bool wasActive = false;
    private audioController audioController;

    // Start is called before the first frame update
    void Start()
    {
        positionA = door.transform.position;
        standardRotation = transform.rotation;
        audioController = GetComponent<audioController>();
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
        door.transform.position = (positionA + new Vector2(moveX, moveY));
        door.transform.rotation = Quaternion.Euler(Vector3.forward * rotation);
        audioController.playDoorSound(true);
    }

    private void closeDoor()
    {
        //moves door to original position
        door.transform.position = (positionA);
        door.transform.rotation = standardRotation;
        audioController.playDoorSound(false);
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

        if (leverScript !=null)
        {
            if (leverScript.isActive)
            {
                return true;
            }
        }
        return false;
    }
}


