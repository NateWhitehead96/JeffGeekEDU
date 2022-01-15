using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSnowball : MonoBehaviour
{
    public GameObject snowball; // a link to the prefab
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // if left click
        {
            GameObject newSnowball = Instantiate(snowball, transform.position, Quaternion.identity); // spawn a new snowball using snowball
            // prefab, our position, and a 0 rotation
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // mouse position in our game
            Vector3 shootDirection = mousePosition - transform.position; // vector math to find the direction we want to shoot in
            newSnowball.GetComponent<Snowball>().moveToPosition = new Vector3(shootDirection.x, shootDirection.y); // apply the shootdirection
        }
        //if (Input.GetKeyDown(KeyCode.Space)) // we hit spacebar and the ball just moves right
        //{
        //    GameObject newSnowball = Instantiate(snowball, transform.position, Quaternion.identity);
        //    newSnowball.GetComponent<Snowball>().moveToPosition = new Vector3(12, transform.position.y);
        //}
    }
}
