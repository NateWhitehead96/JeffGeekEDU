using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIEnemy : MonoBehaviour
{
    public NavMeshAgent agent; // thing to control how it moves
    public Transform player; // to know players position
    public int health; // how much health the enemy has
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BulletScript>()) // if the bullet hits the enemy
        {
            health--; // subtract it's health by 1
            Destroy(other.gameObject); // destroy the bullet
            if(health <= 0)
            {
                Destroy(gameObject); // destroying the enemy when it has 0 health
            }
        }
    }
}
