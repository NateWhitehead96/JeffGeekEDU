using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public Transform exitDoor; // the door we come out of
    public bool inDoor; // to know if we're in the door
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && inDoor == true) // using the E key and being inside the door
        {
            FindObjectOfType<PlayerMove>().transform.position = exitDoor.position; // move the player to the other door
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMove>()) // if the thing colliding with the door is our player
        {
            inDoor = true; // we're now in the door
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMove>())
        {
            inDoor = false; // when we leave the door 
        }
    }
}
