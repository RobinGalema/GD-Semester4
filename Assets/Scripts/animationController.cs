using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationController : MonoBehaviour
{
    // Start is called before the first frame update
    private playerMovement movement;
    private Animator animator;
    private playerMovement.playerState lastState = new playerMovement.playerState();
    void Start()
    {
        movement = GetComponent<playerMovement>();
        animator = GetComponentInChildren<Animator>();
        animator.Play("idle");
        lastState = playerMovement.playerState.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        AnimationUpdate();
    }

    private void AnimationUpdate()
    {
        if (movement.movementState == playerMovement.playerState.Idle && lastState != playerMovement.playerState.Idle)
        {
            animator.SetFloat("animator",0);
            lastState = playerMovement.playerState.Idle;
        }
        else if (movement.movementState == playerMovement.playerState.Walking && lastState != playerMovement.playerState.Walking)
        {
            animator.SetFloat("animator", 1);
            lastState = playerMovement.playerState.Walking;
        }
        else if (movement.movementState == playerMovement.playerState.Jumping && lastState != playerMovement.playerState.Jumping)
        {
            animator.SetFloat("animator", 2);
            lastState = playerMovement.playerState.Jumping;
        }
    }
}
