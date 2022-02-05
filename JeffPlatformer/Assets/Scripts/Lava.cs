using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision) // when we touch the lava
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().moveSpeed += 5; // increase our movespeed by 5
        }
    }

    private void OnCollisionExit2D(Collision2D collision) // when we leave the lava
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().moveSpeed -= 5; // decrease our movespeed by 5
        }
    }
}
