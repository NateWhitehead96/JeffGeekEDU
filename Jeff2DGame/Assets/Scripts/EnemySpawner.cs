using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy; // the enemy we want to spawn
    public int numberOfEnemies; // how many enemies we want to create
    public float timer; // to help spawn enemies (count up always)
    public float spawnTime; // the time it takes to spawn an enemy (when timer = this then we spawn the enemy)
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // when time = spawn time we can create a new enemy. We then will also subtract 1 from our number of enemies
        if(timer >= spawnTime && numberOfEnemies > 0)
        {
            Instantiate(enemy, transform.position, transform.rotation); // creates the enemy
            numberOfEnemies--; // take 1 away since we're spawning 1
            timer = 0; // resets timer
        }
        timer += Time.deltaTime; // continously count timer up :)
    }
}
