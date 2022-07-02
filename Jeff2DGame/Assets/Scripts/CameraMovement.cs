using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed;
    int boundry = 1;
    public int width;
    public int height;
    // Start is called before the first frame update
    void Start()
    {
        width = Screen.width;
        height = Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.mousePosition.x > width - boundry) // if the mouse is to the right, we move the camera to the right
        //{
        //    transform.position -= new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed, 0, 0);
        //}

        //if (Input.mousePosition.x < 0 + boundry) // if the mouse is to the left, move to the left
        //{
        //    transform.position -= new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed, 0, 0);
        //}

        //if (Input.mousePosition.y > height - boundry) // moving up
        //{
        //    transform.position -= new Vector3(0, Input.GetAxisRaw("Mouse Y") * Time.deltaTime * speed, 0);
        //}

        //if (Input.mousePosition.y < 0 + boundry) // moving down
        //{
        //    transform.position -= new Vector3(0, Input.GetAxisRaw("Mouse Y") * Time.deltaTime * speed, 0);
        //}

        if (Input.GetMouseButton(0))
        {
            if (Input.GetAxis("Mouse X") > 0)
            {
                transform.position += new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed,
                                           0.0f, Input.GetAxisRaw("Mouse Y") * Time.deltaTime * speed);
            }

            else if (Input.GetAxis("Mouse X") < 0)
            {
                transform.position += new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed,
                                           0.0f, Input.GetAxisRaw("Mouse Y") * Time.deltaTime * speed);
            }
        }
    }
}
