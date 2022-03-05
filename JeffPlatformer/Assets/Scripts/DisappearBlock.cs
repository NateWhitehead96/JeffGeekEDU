using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearBlock : MonoBehaviour
{
    public float timer;

    public SpriteRenderer sprite; // help with rendering the block

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(HideBlock());
    }

    IEnumerator HideBlock()
    {
        yield return new WaitForSeconds(2); // after 2 seconds hide the stuff
        sprite.enabled = false; // hide the sprite
        GetComponent<BoxCollider2D>().enabled = false; // disable the collider
        yield return new WaitForSeconds(timer); // wait for x seconds
        sprite.enabled = true; // hide the sprite
        GetComponent<BoxCollider2D>().enabled = true; // disable the collider
    }
}
