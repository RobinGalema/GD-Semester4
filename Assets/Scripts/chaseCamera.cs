using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chaseCamera : MonoBehaviour
{
    public bool playerOvertaken = false;
    public bool startedChase = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && startedChase)
        {
            Debug.LogError("player got overtaken by the camera");
            playerOvertaken = true;
        }
    }
}
