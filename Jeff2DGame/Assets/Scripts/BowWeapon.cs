using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowWeapon : MonoBehaviour
{
    public GameObject arrow; // the arrow we're going to shoot
    public List<GameObject> enemies;
    public int damage;
    public float shootSpeed;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemies.Count == 0) return; // checks if enemies are near, if they are not then dont do any more code

        if(timer >= shootSpeed) // timer has hit the shoot speed time
        {
            GameObject newArrow = Instantiate(arrow, transform.position, transform.rotation); // create the arrow
            int randomEnemy = Random.Range(0, enemies.Count); // find a new random enemy near us to shoot at
            newArrow.GetComponent<Projectile>().target = enemies[randomEnemy].transform; // set the arrow target to the random enemy
            timer = 0;
        }
        timer += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
        {
            enemies.Add(collision.gameObject); // add the enemy near us to the list
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
        {
            enemies.Remove(collision.gameObject); // remove the enemy near us to the list
        }
    }
}
