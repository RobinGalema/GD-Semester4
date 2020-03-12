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
    public Transform fallDetector;
    public bool isMainPayer;

    private Rigidbody2D rb;
    private float horizontalMovement = 0f;
    private bool isGrounded;
    private Vector2 spawnPos;
    public string controllerSuffix;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spawnPos = rb.position;
        Debug.Log(Input.GetJoystickNames()[1]);
    }

    // Update is called once per frame
    void Update()
    {
        getInput();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMovement * movespeed, rb.velocity.y);
    }

    /// <summary>
    /// Resets the player to their spawning position
    /// </summary>
    private void resetPlayer()
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
        if (isMainPayer)
        {
            // Movement input
            horizontalMovement = Input.GetAxisRaw("Horizontal1");

            if (Input.GetButtonDown("Sneak1") && isGrounded)
            {
                Debug.Log("Sneaking");
                sneak();
            }

            if (Input.GetJoystickNames()[0] == "Wireless Controller")
            {
                // Check jump input
                if (Input.GetButtonDown("Jump1PS4") && isGrounded)
                {
                    Debug.Log("Jump button pressed [P1]");
                    rb.velocity = Vector2.up * jumpForce;
                }

                controllerSuffix = "1PS4";
            }
            else if (Input.GetJoystickNames()[0] == "Controller (XBOX 360 For Windows)")
            {
                // Check jump input
                if (Input.GetButtonDown("Jump1X360") && isGrounded)
                {
                    Debug.Log("Jump button pressed [P1]");
                    rb.velocity = Vector2.up * jumpForce;
                }

                controllerSuffix = "1X360";
            }
           
        }
        else
        {
            horizontalMovement = Input.GetAxisRaw("Horizontal2");

            // Check sneak input
            if (Input.GetButtonDown("Sneak2") && isGrounded)
            {
                Debug.Log("Sneaking");
                sneak();
            }

            if (Input.GetJoystickNames()[1] == "Wireless Controller")
            {
                // Check jump input
                if (Input.GetButtonDown("Jump2PS4") && isGrounded)
                {
                    Debug.Log("Jump button pressed [P1]");
                    rb.velocity = Vector2.up * jumpForce;
                }

                controllerSuffix = "2PS4";
            }
            else if (Input.GetJoystickNames()[1] == "Controller (XBOX 360 For Windows)")
            {
                // Check jump input
                if (Input.GetButtonDown("Jump2X360") && isGrounded)
                {
                    Debug.Log("Jump button pressed [P1]");
                    rb.velocity = Vector2.up * jumpForce;
                }

                controllerSuffix = "2X360";
            }
        }

        // Check if this player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        if (!isGrounded)
        {
            gameObject.layer = 0;
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsPlayer);
            gameObject.layer = 9;
        }

        // Check if the player fell out of the level
        if (rb.position.y < fallDetector.position.y)
        {
            resetPlayer();
        }
    }
}

