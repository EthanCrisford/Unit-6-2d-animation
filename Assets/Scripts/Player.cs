using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    Animator animator;
    float horizontal;
    string currentState;
    const string idle = "Idle";
    const string walk = "walk";
    public GameObject explosionPrefab;


    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.Play(idle);
        gameObject.tag = "Player";
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
    
    private void OnTriggerEnter2D(Collider2D diamond)
    {
        GameObject prefab;
        if (diamond.tag == "Diamond")
        {
            // make a clone of the explosion prefab
            prefab = Instantiate(explosionPrefab);

            // set the position of the explosion to be the same as the diamond
            prefab.transform.position = diamond.transform.position;
            Destroy(diamond.gameObject);
        }
    }
   

    void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;

        animator.Play(newState);

        currentState = newState;
    }

   
}




