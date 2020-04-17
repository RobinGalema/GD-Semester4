using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lever : MonoBehaviour
{
    public bool isActive;
    public Transform parentTransform;
    public GameObject xButtonIcon;

    private bool playerInRange = false;
    private string controllerSuffix;
    private audioController AudioController;

    private void Start()
    {
       isActive = false;
       xButtonIcon.SetActive(false);
       AudioController = GetComponent<audioController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player is in range of the button and then check if the interaction button is pressed
        if (playerInRange)
        {
            if (Input.GetButtonDown("X" + controllerSuffix))
            {
                Debug.Log(" ---> The player interacted with the button.");
                changeLeverState();

                if (isActive)
                {
                   parentTransform.localScale = new Vector3(transform.localScale.x, -1, 1);
                    AudioController.playLeverSound(true);
                }
                else
                {
                    parentTransform.localScale = new Vector3(transform.localScale.x, 1, 1);
                    AudioController.playLeverSound(false);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("--- Player in button range ---");
            controllerSuffix = collision.GetComponent<playerMovement>().controllerSuffix;
            playerInRange = true;
            xButtonIcon.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("--- Player leaving button range ---");
            playerInRange = false;
            xButtonIcon.SetActive(false);
        }
    }

    private void changeLeverState()
    {
        // Change isActive to its opposite
            isActive = !isActive;
        Debug.Log("---> Is the lever active? : " + isActive);
        if (isActive)
        {
            xButtonIcon.SetActive(false);
        }
    }
}
