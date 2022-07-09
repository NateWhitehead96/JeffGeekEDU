using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int damage;
    public int health;
    public float speed;
    public GameObject target; // one of the characters that touch this enemy will be this target
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
