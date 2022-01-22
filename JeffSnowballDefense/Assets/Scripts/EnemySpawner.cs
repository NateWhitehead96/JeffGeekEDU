using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float bounds; // to make sure enemies get spawned inside the camera view
    public GameObject Enemy; // the prefab enemy to spawn

    public float timer; // in game clock
    public float SpawnTime = 2; // every 2 seconds spawn the enemy

    public int NumberOfEnemies; // at the start of a wave, we'll set this number and everytime we spawn an enemy, lower this number
    public int maxSpeed; // max speed of the enemy
    // Start is called before the first frame update
    void Start()
    {
        NumberOfEnemies = 3; // game starts with 3 enemies
        maxSpeed = ScoreManager.Waves + 2; // the max speed of an enemy will be whatever wave we're on + 2 (3) to start
    }

    // Update is called once per frame
    void Update()
    {
        if(timer >= SpawnTime && NumberOfEnemies > 0) // our clock reaches the spawntime, check to make sure there's enemies to spawn still
        {
            float randomY = Random.Range(-bounds, bounds); // find a new height between the bottom and top of our screen
            int randomSpeed = Random.Range(1, maxSpeed); // find a new random speed for the enemy
            GameObject newEnemy = Instantiate(Enemy, new Vector3(transform.position.x, randomY), transform.rotation); // spawn an enemy at our new random height with 0 rotation
            newEnemy.GetComponent<Enemy>().moveSpeed = randomSpeed; // apply that speed to our enemy
            timer = 0; // reset the clock

            NumberOfEnemies--; // subtract 1 enemy from the total number of enemies
            if(NumberOfEnemies <= 0) // when we run out of enemies for that wave
            {
                StartCoroutine(NextWave());
            }
        }
        timer += Time.deltaTime; // make sure our clock counts up using real time
    }

    IEnumerator NextWave()
    {
        yield return new WaitForSeconds(5); // wait for 5 seconds
        ScoreManager.Waves++; // increase the wave number by 1
        NumberOfEnemies += ScoreManager.Waves * 3; // set a new number of enemies to be 3x the current wave (wave = 2, enemies = 6)
        maxSpeed++;
        if(SpawnTime > 1) // to check to see if enemy spawn is at cap
        {
            SpawnTime -= 0.1f; // decrease time needed between enemy spawns
        }
    }
}
