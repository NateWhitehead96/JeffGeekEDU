using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PencilTip : MonoBehaviour
{
    public int speed;
    public Player player; // access to direction
    public Player2 player2; // access to direction for player 2
    public int direction; // pencil tips direction
    public bool ownedByP1; // a bool to know if the tip is from player 1 or not
    // Start is called before the first frame update
    void Start()
    {
        if(ownedByP1 == true) // if the tip is for the first player
        {
            player = FindObjectOfType<Player>(); // so the tips we create during play instantly know what player is
            direction = player.direction; // whatever direction player was in when they shoot the tip, should be this direction
        }
        else // if the owning player is player 2
        {
            player2 = FindObjectOfType<Player2>();
            direction = player2.direction; // whatever direction player was in when they shoot the tip, should be this direction
        }
        transform.localScale = new Vector3(transform.localScale.x * direction, transform.localScale.y); // make sure its facing the right direction
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + speed * direction * Time.deltaTime, transform.position.y); // move the tip

        if(transform.position.x > 15 || transform.position.x < -15) // if the tip goes off screen
        {
            Destroy(gameObject); // destroy it son
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject); // if the tip touches either player, destroy self
        }
    }
}
