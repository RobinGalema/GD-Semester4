using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationController : MonoBehaviour
{
    // Start is called before the first frame update
    private playerMovement movement;
    private Animator animator;
    void Start()
    {
        movement = GetComponent<playerMovement>();
        animator = GetComponentInChildren<Animator>();
        animator.Play("walking");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
