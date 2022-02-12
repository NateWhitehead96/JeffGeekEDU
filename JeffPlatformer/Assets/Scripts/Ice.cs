using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision) // when we touch the ice
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().moveSpeed -= 3; // decrease speed by 3
        }
    }

    private void OnCollisionExit2D(Collision2D collision) // when we leave the ice
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().moveSpeed += 3; // increase our movespeed by 3
        }
    }
}
