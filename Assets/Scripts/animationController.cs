using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class animationController : MonoBehaviour
{
    private stateController state;
    private Animator animator;
    private stateController.movementState lastState;

    void Start()
    {
        state = GetComponent<stateController>();
        animator = GetComponentInChildren<Animator>();
        animator.Play("idle");
    }

    // Update is called once per frame
    void Update()
    {
       if (didStateChange())
        {
            setAnimation();
        }
    }

    void setAnimation()
    {
        Debug.Log("State changed, changing animation");

        switch (state.currentMoveState)
        {
            case stateController.movementState.Idle:
                // Idle
                animator.SetTrigger("ToIdle");
                break;

            case stateController.movementState.Walking:
                //Walking
                animator.SetTrigger("ToWalk");
                break;

            case stateController.movementState.Jumping:
                //jumping
                animator.SetTrigger("ToJump");
                break;

            default:
                //Idle
                animator.SetTrigger("ToIdle");
                break;
        }
    }

    public bool didStateChange()
    {
        if (state.currentMoveState != lastState)
        {
            Debug.Log("---> The state of the player has changed, new state ---> " + state.currentMoveState);
            lastState = state.currentMoveState;
            return true;
        }
        else
        {
            return false;
        }
    }
}
