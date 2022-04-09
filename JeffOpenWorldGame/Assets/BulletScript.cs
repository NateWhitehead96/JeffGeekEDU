using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float expiredTime; // how much time its allowed on screen
    public Rigidbody rb; // help with movement
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        expiredTime += Time.deltaTime; // counting up
        rb.AddForce(transform.forward * 10);
        

        if(expiredTime >= 5) // if the bullet is on screen for more than 5 seconds, destroy it
        {
            Destroy(gameObject);
        }
    }
}
