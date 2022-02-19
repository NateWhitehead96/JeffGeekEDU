using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PencilTip : MonoBehaviour
{
    public int speed;
    public Player player; // access to direction
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>(); // so the tips we create during play instantly know what player is
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + speed * player.direction * Time.deltaTime, transform.position.y); // move the tip
        transform.localScale = new Vector3(transform.localScale.x * player.direction, transform.localScale.y); // make sure its facing the right direction
    }
}
