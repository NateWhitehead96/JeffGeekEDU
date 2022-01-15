using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // int is a whole number, 1, 2 ,3 ,etc
    public int moveSpeed; // variable for how fast our player can move
    // float is a decimal number 3.5, 2.7, 5.9, etc
    public float bounds; // tell us the bounds, or how high/low the player can move
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) && transform.position.y < bounds) // when the W key is press do something
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime); // moving up
        }
        if (Input.GetKey(KeyCode.S) && transform.position.y > -bounds) // when the S key is press do something
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime); // moving Down
        }
    }
}
