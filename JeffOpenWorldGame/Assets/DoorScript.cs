using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public Transform newArea; // the area we move to when we interact with the door
    public bool inDoor; // help know when the player is inside/touching the door
    public Transform player; // help move player around
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>().transform; // assign the player
    }

    // Update is called once per frame
    void Update()
    {
        if(inDoor == true && Input.GetKeyDown(KeyCode.E))
        {
            player.transform.position = newArea.position; // send the player to that spot
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) // if the player is touching the door
        {
            inDoor = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) // when the player leaves the door
        {
            inDoor = false;
        }
    }
}
