using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    Animator animator;
    float horizontal;
    private string currentState;
    string idle;
    string newState;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.Play("idle");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("d") == true)

            myRigidbody.velocity = new Vector2(5, 0);

    }

    void ChangeAnimationState(string newState)
    {
        if (currentState == idle) return;

        animator.Play("idle");

        currentState = newState;

    }

}
