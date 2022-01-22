using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // int is a whole number, 1, 2 ,3 ,etc
    public int moveSpeed; // variable for how fast our player can move
    // float is a decimal number 3.5, 2.7, 5.9, etc
    public float bounds; // tell us the bounds, or how high/low the player can move

    public GameObject PauseCanvas; // the reference to the pause
    // Start is called before the first frame update
    void Start()
    {
        PauseCanvas.SetActive(false); // hide the canvas when we start the game
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

        if (Input.GetKeyDown(KeyCode.E)) // when we hit e, we will pause
        {
            PauseCanvas.SetActive(true); // make the pause visible
            Time.timeScale = 0; // set time scale to 0 to stop all other scripts from updating aka pause everything
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit(); // will close the game, only works outside of editor in built version
        }
    }
}
