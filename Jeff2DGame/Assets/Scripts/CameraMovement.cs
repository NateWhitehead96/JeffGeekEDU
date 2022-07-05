using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed;
    int boundry = 1;
    public int width;
    public int height;
    public Vector3 mousePosition; // where our mouse is on the screen
    // Start is called before the first frame update
    void Start()
    {
        width = Screen.width;
        height = Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // constantly update our mouse position
        
        if(mousePosition.x > transform.position.x + 9.5f) // going to the right, mouse position is greater than camera position
        {
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, -10);
        }
        if(mousePosition.x < transform.position.x - 9.5f) // going to the left when the mouse position is less than camera position
        {
            transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, -10);
        }
        if(mousePosition.y > transform.position.y + 4.5f) // going up when the mouse position is higher than the camera
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, -10);
        }
        if(mousePosition.y < transform.position.y - 4.5f) // going down when the mouse position is under the camera
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, -10);
        }
    }
}
