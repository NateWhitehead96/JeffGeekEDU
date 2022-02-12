using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed; // how fast our player can move
    public float jumpForce; // how high we can jump

    public Rigidbody2D rb; // the link to our rigidbody
    private SpriteRenderer sprite; // to help flip direction of the player
    //private Animator animator; // the animation controller

    public bool walking; // these will just help with animations
    public bool jumping;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // our rb is now linked to the rigidbody component on the game object
        sprite = GetComponent<SpriteRenderer>(); // link sprite to the sprite on this game object
        //animator = GetComponent<Animator>(); // link our animator to the animator controller
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D)) // moving right hitting D key
        {
            transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
            sprite.flipX = false; // flip the sprite to face right
            walking = true;
        }
        else if (Input.GetKeyUp(KeyCode.D)) // when we release the key
        {
            walking = false;
        }
        if (Input.GetKey(KeyCode.A)) // moving left hitting A key
        {
            transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
            sprite.flipX = true; // flip the sprite to face left
            walking = true;
        }
        else if (Input.GetKeyUp(KeyCode.A)) // when the key is released
        {
            walking = false;
        }

        //animator.SetBool("isWalking", walking); // handle the walking animation
        //animator.SetBool("isJumping", jumping); // handle the jumping animation

        if (Input.GetKeyDown(KeyCode.Space)) // jumping with spacebar
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            jumping = true;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        jumping = false; // when we collide with anything we are not jumping no mo
    }
}
