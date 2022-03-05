using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public float moveSpeed; // how fast our player can move
    public float jumpForce; // how high we can jump

    public Rigidbody2D rb; // the link to our rigidbody
    private SpriteRenderer sprite; // to help flip direction of the player
    //private Animator animator; // the animation controller

    public bool walking; // these will just help with animations
    public bool jumping;

    public GameObject Pencil; // the pencil in the players hands
    public int direction; // the direction the player is facing

    public Transform shootPosition; // that red dot that our tip will come out of
    public GameObject PencilTip; // the projectile pencil tip

    public int Health; // how much health player 2 has
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
        if (Input.GetKey(KeyCode.RightArrow)) // moving right hitting D key
        {
            transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
            //sprite.flipX = false; // flip the sprite to face right
            transform.localScale = new Vector3(0.2f, 0.2f); // makes sure the whole body is facing to the right (the scale is positive on the x)
            direction = 1; // to face positive, right
            walking = true;
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow)) // when we release the key
        {
            walking = false;
        }
        if (Input.GetKey(KeyCode.LeftArrow)) // moving left hitting A key
        {
            transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
            //sprite.flipX = true; // flip the sprite to face left
            transform.localScale = new Vector3(-0.2f, 0.2f); // makes sure the whole body is facing left (the scale is negative on the x)
            direction = -1; // to face negative, left
            walking = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow)) // when the key is released
        {
            walking = false;
        }

        //animator.SetBool("isWalking", walking); // handle the walking animation
        //animator.SetBool("isJumping", jumping); // handle the jumping animation

        if (Input.GetKeyDown(KeyCode.UpArrow)) // jumping with up arrow
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            jumping = true;
        }

        if (Input.GetKeyDown(KeyCode.RightControl)) // attacking with pencil
        {
            StartCoroutine(Attack()); // start a coroutine to attack with the pencil
        }

        if (Input.GetKeyDown(KeyCode.RightShift)) // firing of the tip
        {
            Instantiate(PencilTip, shootPosition.position, shootPosition.rotation); // spawning the tip at our shoot position
        }
    }

    IEnumerator Attack()
    {
        Pencil.transform.position = new Vector3(Pencil.transform.position.x + 0.5f * direction, Pencil.transform.position.y); // the pencil moving forward
        yield return new WaitForSeconds(0.2f);
        Pencil.transform.position = new Vector3(Pencil.transform.position.x - 0.5f * direction, Pencil.transform.position.y); // the pencil back in position
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        jumping = false; // when we collide with anything we are not jumping no mo
        if (collision.gameObject.CompareTag("Bouncy")) // landing on the bouncy tile
        {
            rb.AddForce(Vector2.up * 20, ForceMode2D.Impulse); // add a lot of force up
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player1Pencil"))
        {
            Health--;
            // drop the key
            if(Health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
