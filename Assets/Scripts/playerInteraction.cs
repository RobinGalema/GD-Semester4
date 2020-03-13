using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInteraction : MonoBehaviour
{
    playerMovement playerController;
    // Start is called before the first frame update 
    void Start()
    {
        playerController = GetComponent<playerMovement>();
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Spike")
        {
            playerController.resetPlayer();
        }
    }
}
