using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float xAxis;
    float yAxis;
    int groundMask;
    bool isGrounded;
    bool isJumping;
    Animator animator;
    private string currentState;
    Rigidbody2D rb2d;

    //Animaton States
    const string idle = "idle";
    const string run = "run";
    const string jump = "jump";
    const string attack = "attack";



    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        groundMask = 1 
    }

    void ChangeAnimationState(string newState)
    {
        //stop the same animation from interupting itself
        if (currentState == newState) return;

        //play the animation
       animator.Play(newState);

        //reassign the current state
        currentState = newState;

    }
}
