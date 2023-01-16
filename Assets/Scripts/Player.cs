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
    AudioSource audioSource;
    public AudioClip walkSound;
    public AudioClip pickupSound;
    public float AudioVolume;


    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.Play(idle);
        gameObject.tag = "Player";
        audioSource = GetComponent<AudioSource>();
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
            ChangeAnimationState("idle");
        }

        //if (Input.GetKey("a") == true)
        {
            //myRigidbody.velocity = new Vector2(-5, 0);
            //ChangeAnimationState("walk");
            //gameObject.transform.Rotate(new Vector3(0,100,0)); 
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
            PlaySoundEffectPickup();
        }
    }


    void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;

        animator.Play(newState);

        PlaySoundEffectWalk();

        currentState = newState;
    }

    void PlaySoundEffectWalk()
    {
        audioSource.PlayOneShot(walkSound);
    }

    void PlaySoundEffectPickup()
    {
        audioSource.PlayOneShot(pickupSound);
    }

}




