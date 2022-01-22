using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int moveSpeed; // how fast the enemy will move
    public Animator animator; // reference to our animation controller
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>(); // setting and making sure that our animator is set to the right animator
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y); // move the enemy to the left

        if (transform.position.x < -12) // if the enemy goes behind the player, destroy the enemy
        {
            ScoreManager.Lives--; // subtract 1 life from our lives total
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) // collision function
    {
        if (collision.gameObject.CompareTag("Snowball")) // the thing the enemy is colliding with is Snowball
        {
            ScoreManager.Score++; // increase our score by 1
            Destroy(collision.gameObject); // destroy the snowball
            StartCoroutine(DyingAnimation()); // start a new delay to play dying animation, then destroy enemy
        }
    }

    IEnumerator DyingAnimation()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false; // makes sure the collider is turned off to allow enemies and snowballs to pass
        moveSpeed = 0; // stop the dying enemy from moving
        animator.SetBool("isDying", true); // switch the animation to dying
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 1; // add gravity to the enemy, to drag the enemy down the screen
        yield return new WaitForSeconds(2); // required for Coroutines, a delay
        Destroy(gameObject); // destroy the enemy
    }

}
