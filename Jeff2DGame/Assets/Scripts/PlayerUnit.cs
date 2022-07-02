using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : MonoBehaviour
{
    public bool selected; // to know if this unit is selected by the player
    public Vector3 movePosition; // where the thing will move to
    public LayerMask unit;
    // Start is called before the first frame update
    void Start()
    {
        movePosition = transform.position;

    }

    private void OnMouseDown() // when we click on this character
    {
        if (selected == false) // has it been selected, if not
            selected = true; // make it true
        else // it is selected
            selected = false; // unselect the character
        print("Works?");
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector3.forward, Mathf.Infinity, unit);
        //    if (hit.collider == null)
        //    {
        //        selected = false;
        //        print("Works?");
        //    }
        //}

        if (Input.GetMouseButtonDown(1) && selected == true)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            movePosition = new Vector3(mousePos.x, mousePos.y);
        }
        transform.position = Vector3.MoveTowards(transform.position, movePosition, Time.deltaTime);
    }
}
