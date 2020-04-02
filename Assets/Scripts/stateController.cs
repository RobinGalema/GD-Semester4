using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stateController : MonoBehaviour
{ 
    public enum movementState
    {
        Idle, Walking, Jumping, Falling, Dragging
    }

    public movementState currentMoveState = new movementState();

    private playerMovement movement;
    private movementState lastState;

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<playerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        checkForState();
        didStateChange();
        Debug.Log("Current state: " + currentMoveState);
    }

    /// <summary>
    /// A function that changes the state of the player based on input and player movement
    /// </summary>
    void checkForState()
    {
        if (movement.horizontalMovement == 0 && !movement.isDragging && movement.isGrounded)
        {
            currentMoveState = movementState.Idle;
        }
        else if (movement.horizontalMovement != 0 && !movement.isDragging && movement.isGrounded)
        {
            currentMoveState = movementState.Walking;
        }
        else if (!movement.isGrounded)
        {
            currentMoveState = movementState.Jumping;
        }
        else if (movement.isDragging && movement.isGrounded)
        {
            currentMoveState = movementState.Dragging;
        }
        else
        {
            Debug.LogError("!! THERE IS NO AVAILIBLE STATE !!");
        }
    }

    /// <summary>
    /// A function that checks if the state of the player has changed
    /// </summary>
    /// <returns>True if the state changed, False if the state didn't change.</returns>
    public bool didStateChange()
    {
        if (currentMoveState != lastState)
        {
            Debug.Log("---> The state of the player has changed, new state ---> " + currentMoveState);
            lastState = currentMoveState;
            return true;
        }
        else
        {
            return false;
        }
    }
}
