using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    float horizontal;

    [SerializeField]
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Input.GetAxis("Horizontal");

        Movement(horizontal);
    }

    private void Movement(float horizontal)
    {
        if(Input.GetKeyDown("d"))
        myRigidbody.velocity = new Vector2(horizontal * speed, myRigidbody.velocity.y);
    }
}
