using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    private playerMovement Player;
    private Vector2 checkPointPos;


    private void Start()
    {
        checkPointPos = transform.localPosition;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player = other.gameObject.GetComponent<playerMovement>();
            Player.spawnPos = checkPointPos;
            Debug.Log("checkpoint changed");
        }
    }
}
