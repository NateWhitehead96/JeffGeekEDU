using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // access to the slider

public enum Brain
{
    walk,
    attack
}

public class Enemy : MonoBehaviour
{
    public int damage;
    public int health;
    public float speed;
    public GameObject target; // one of the characters that touch this enemy will be this target
    public Slider healthBar; // access to the enemy healthbar
    public Brain brain; // how we control what our AI does
    public Path path; // what path we take
    public int currentPoint; // the current checkpoint the enemy is moving towards
    // Start is called before the first frame update
    void Start()
    {
        healthBar.maxValue = health; // set max health to be whatever this thing starts with
        healthBar.gameObject.SetActive(false); // hides the health bar
        path = FindObjectOfType<Path>(); // find whatever path is in our map, and make sure the enemy knows about it
    }

    // Update is called once per frame
    void Update()
    {
        if(brain == Brain.walk) // enemy is following the path
        {
            transform.position = Vector3.MoveTowards(transform.position, path.checkpoints[currentPoint].position, speed * Time.deltaTime);
            float distance = Vector3.Distance(transform.position, path.checkpoints[currentPoint].position); // find distance
            if(distance <= 0.05f) // if we're on the checkpoint we were moving to
            {
                currentPoint++; // increase current point by 1, so that now our enemy moves to the next point
            }
        }

        if(health < healthBar.maxValue)
        {
            healthBar.gameObject.SetActive(true); // shows the health bar
            healthBar.value = health; // update our health bar slider
        }
        if(health <= 0)
        {
            Destroy(gameObject); // kill the enemy when it has 0 health
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerUnit>()) // the character is touching the enemy
        {
            target = collision.gameObject; // the unit becomes the target
            brain = Brain.attack; // set the enemy to attack mode
            InvokeRepeating("AttackPlayer", 1, 2); // repreat the function AttackPlayer every 2 seconds, either until player dies or is too far
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerUnit>()) // the character is touching the enemy
        {
            target = null; // there is no target anymore
            brain = Brain.walk; // reset
            CancelInvoke(); // stop attack player
        }
    }

    public void AttackPlayer()
    {
        target.GetComponent<PlayerUnit>().health -= damage; // deal enemy damage to the unit
    }
}
