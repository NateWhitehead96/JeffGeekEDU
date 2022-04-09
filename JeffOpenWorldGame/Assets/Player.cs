using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody rb;
    public float jumpForce;
    public bool jumping; // if we have jumped or not
    public int balloonSize; // help with knowing how much jump force to apply
    public float horizontalSpeed; // how fast we rotate left and right
    public float verticalSpeed; // how fast we rotate up and down

    public float xRotation; // hold our x rotations
    public float yRotation; // holds our y rotations

    public Vector3 moveDirection; // forward position

    public GameObject Map; // access to the map canvas

    // bullet stuff
    public Transform shootPosition; // where the projectile comes from
    public GameObject bullet; // the thing we're shooting
    public float bulletForce; // how fast the bullet goes
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // to link the rigidbody
        Cursor.lockState = CursorLockMode.Locked; // have the mouse locked in the middle of the screen
        Map.SetActive(false); // make sure map is not on screen when we play
    }

    // Update is called once per frame
    void Update()
    {
        Move(); // make sure we use the function in update so it runs every frame
        Rotate(); // make sure we can rotate when playing
        Jump(); // make sure we can jump
        OpenMap(); // toggle the map (open and close it)
        ShootBullet(); // to shoot our bullet
    }

    void ShootBullet()
    {
        if (Input.GetMouseButtonDown(0)) // left click
        {
            GameObject newBullet = Instantiate(bullet, shootPosition.position, shootPosition.rotation); // spawn the bullet
            newBullet.GetComponent<Rigidbody>().AddForce(shootPosition.forward * bulletForce); // adding force to bullet
        }
    }

    void OpenMap()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (Map.activeInHierarchy) // the map is open on screen
            {
                Map.SetActive(false);
            }
            else // the map is not on screen
            {
                Map.SetActive(true);
            }
        }
    }
    void Move() // handle all of our movement stuff
    {
        float horizontal = Input.GetAxisRaw("Horizontal"); // forward and backward inputs without using keycodes
        float vertical = Input.GetAxisRaw("Vertical"); // left and right inputs
        moveDirection = (transform.forward * vertical) + (transform.right * horizontal); // combining imputs to find a new forward direction
        Vector3 force = moveDirection * (moveSpeed * Time.deltaTime); // create force to multiply on our new forward direction
        transform.position += force; // apply all of the stuff to our position
    }

    void Rotate() // handle the player rotation, which rotates the player around by the mouse position
    {
        float mouseX = Input.GetAxisRaw("Mouse X");
        yRotation = mouseX * horizontalSpeed * Time.deltaTime; // rotating around the y axis using our mouse left and right position
        float mouseY = Input.GetAxisRaw("Mouse Y");
        xRotation = mouseY * verticalSpeed * Time.deltaTime; // rotating around the x axis using our mouse up and down position

        Vector3 playerRotation = transform.rotation.eulerAngles; // store player rotation
        playerRotation.y += yRotation; // apply the mouse y rotation
        playerRotation.x -= xRotation; // apply the mouse x rotation
        transform.rotation = Quaternion.Euler(playerRotation); // apply all rotations to the player's rotation
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumping == false)
        {
            rb.AddForce(Vector3.up * (jumpForce * balloonSize), ForceMode.Impulse); // jump up
            jumping = true;
            //Physics.gravity = new Vector3(0, -12, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        jumping = false; // colliding with anything, most likely the ground
    }
}
