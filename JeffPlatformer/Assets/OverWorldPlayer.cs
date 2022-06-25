using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverWorldPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        transform.position = new Vector3(transform.position.x + x * Time.deltaTime * 10, transform.position.y + y * Time.deltaTime * 10);
    }
}
