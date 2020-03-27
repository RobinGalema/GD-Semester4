using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float movespeed = 5f;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public LayerMask whatIsPlayer;
    public float jumpForce;
    public Vector2 spawnPos;
    public string controllerSuffix;
    [HideInInspector] public int controllerNumber;

    private Rigidbody2D rb;
    [HideInInspector] public float horizontalMovement = 0f;
    [HideInInspector] public bool isDragging;
    private bool isGrounded;
    
    public enum playerState
    {
        Idle, Walking, Jumping, Falling, Dragging
    }

    public playerState movementState = new playerState();

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spawnPos = rb.position;
        isDragging = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (controllerSuffix != "")
        {
            getInput();
            stateChecks();
        }
        Debug.Log(movementState);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMovement * movespeed, rb.velocity.y);
    }

    /// <summary>
    /// Resets the player to their spawning position
    /// </summary>
    public void resetPlayer()
    {
        // Player gets reset
        Debug.Log("--- Resetting player to spawning position ---");
        rb.position = spawnPos;
    }

    private void sneak()
    {
        // Change animation to sneaking and sneak
    }

    private void getInput()
    {
        try
        {
            // Basic movement
            horizontalMovement = Input.GetAxisRaw("Horizontal" + controllerSuffix);
            if (horizontalMovement != 0 && isGrounded && !isDragging)
            {
                movementState = playerState.Walking;
                Debug.Log("state: Walking");
            }
            else if (horizontalMovement == 0 && isGrounded && !isDragging)
            {
                Debug.Log("state: Idle");
                movementState = playerState.Idle;
            }

            // Jumping
            if (Input.GetButtonDown("A" + controllerSuffix) && isGrounded)
            {
                rb.velocity = Vector2.up * jumpForce;
                movementState = playerState.Jumping;
                Debug.Log("state: Jumping");
            }

            // Sneaking
            if (Input.GetButtonDown("LB" + controllerSuffix))
            {
                Debug.Log(controllerSuffix + " pressed the sneak button");
                // Sneak
            }
        }
        catch
        {
            Debug.LogError("No controller set-up for player");
        }
    }

    private void stateChecks()
    {
        // Check if this player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        if (!isGrounded)
        {
            gameObject.layer = 0;
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsPlayer);
            gameObject.layer = 9;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the player collided with the fall detection which would mean they fell out of the level
        if (collision.tag == "fallDetection")
        {
            // Reset the player
            Debug.Log("player collided with the falldetector");
            resetPlayer();
        }
    }
}

