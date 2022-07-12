using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // access to the slider

public class Enemy : MonoBehaviour
{
    public int damage;
    public int health;
    public float speed;
    public GameObject target; // one of the characters that touch this enemy will be this target
    public Slider healthBar; // access to the enemy healthbar
    // Start is called before the first frame update
    void Start()
    {
        healthBar.maxValue = health; // set max health to be whatever this thing starts with
        healthBar.gameObject.SetActive(false); // hides the health bar
    }

    // Update is called once per frame
    void Update()
    {
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
            InvokeRepeating("AttackPlayer", 1, 2); // repreat the function AttackPlayer every 2 seconds, either until player dies or is too far
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerUnit>()) // the character is touching the enemy
        {
            target = null; // there is no target anymore
            CancelInvoke(); // stop attack player
        }
    }

    public void AttackPlayer()
    {
        target.GetComponent<PlayerUnit>().health -= damage; // deal enemy damage to the unit
    }
}
