using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Transform target; // where the arrow will go
    public float speed; // how fast arrow moves
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime); // how the arrow moves
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
        {
            collision.gameObject.GetComponent<Enemy>().health--; // deal damage to enemy
            Destroy(gameObject);
        }
    }
}
