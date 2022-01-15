using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball : MonoBehaviour
{
    public Vector3 moveToPosition; // the position we're moving the snowball to
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveToPosition * Time.deltaTime); // translate/move the snowball to a set destination

        if (transform.position.x > 12 || transform.position.y > 6 || transform.position.y < -6) // bounds check to make sure snowball is
                                                                                                // in the play area
        {
            Destroy(gameObject);
        }
    }
}
