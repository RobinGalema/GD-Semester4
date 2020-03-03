using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float movespeed = 5f;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public float jumpForce;
    public Transform fallDetector;

    private Rigidbody2D rb;
    private float horizontalMovement = 0f;
    private bool isGrounded;
    private Vector2 spawnPos;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spawnPos = rb.position;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        horizontalMovement = Input.GetAxisRaw("Horizontal");

        // Check jump input
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Debug.Log("Space pressed0");
            rb.velocity = Vector2.up * jumpForce;
        }

        // Check if the player fell out of the level
        if (rb.position.y < fallDetector.position.y)
        {
            resetPlayer();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMovement * movespeed, rb.velocity.y);
    }

    private void resetPlayer()
    {
        // Player gets reset
        Debug.Log("--- Resetting player to spawning position ---");
        rb.position = spawnPos;
    }
}

