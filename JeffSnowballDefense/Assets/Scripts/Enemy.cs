using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int moveSpeed; // how fast the enemy will move
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y); // move the enemy to the left

        if (transform.position.x < -12) // if the enemy goes behind the player, destroy the enemy
        {
            Destroy(gameObject);
        }
    }


}
