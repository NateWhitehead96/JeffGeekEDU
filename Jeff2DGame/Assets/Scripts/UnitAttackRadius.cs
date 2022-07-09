using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAttackRadius : MonoBehaviour
{
    public PlayerUnit player; // access to the character so we can add and subtract enemies from our list

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>()) // when we collide with an enemy
        {
            player.EnemiesInRange.Add(collision.gameObject); // add that new enemy to our list
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>()) // when we collide with an enemy
        {
            player.EnemiesInRange.Remove(collision.gameObject); // remove the enemy from our list
        }
    }
}
