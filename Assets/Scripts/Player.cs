using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    Animator animator;
    float horizontal;
    string currentState;
    const string idle = "idle";
    const string walk = "walk";

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.Play(idle);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("d") == true)
        {
            myRigidbody.velocity = new Vector2(5, 0);
            ChangeAnimationState("walk");
        }
        else
        {
            myRigidbody.velocity = new Vector2(0, 0);
            ChangeAnimationState("Idle");
        }
    }

    void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;

        animator.Play(newState);

        currentState = newState;
    }
}




