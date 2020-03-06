using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lever : MonoBehaviour
{
    public bool isActive;

    private bool playerInRange = false;

    private void Start()
    {
        isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player is in range of the button and then check if the interaction button is pressed
        if (playerInRange)
        {
            if (Input.GetButtonDown("Submit"))
            {
                Debug.Log(" ---> The player interacted with the button.");
                changeLeverState();

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("--- Player in button range ---");
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("--- Player leaving button range ---");
            playerInRange = false;
        }
    }

    private void changeLeverState()
    {
        // Change isActive to its opposite
            isActive = !isActive;
        Debug.Log("---> Is the lever active? : " + isActive);
    }
}
