using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : MonoBehaviour
{
    public bool selected; // to know if this unit is selected by the player
    public Vector3 movePosition; // where the thing will move to
    public LayerMask unit;

    public SpriteRenderer sprite; // help us change the color and or the sprite of the unit
    public Color selectedColor; // the color the character will turn when selected
    public Color notSelectedColor; // the color the character will turn when not selected
    // Start is called before the first frame update
    void Start()
    {
        movePosition = transform.position;
        sprite = GetComponent<SpriteRenderer>(); // make sure our sprite is the right one
    }

    private void OnMouseDown() // when we click on this character
    {
        if (selected == false) // has it been selected, if not
        {
            selected = true; // make it true
            sprite.color = selectedColor;
        }
        else // it is selected
        {
            selected = false; // unselect the character
            sprite.color = notSelectedColor;
        }
        print("Works?");
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetMouseButtonDown(1) && selected == true)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            movePosition = new Vector3(mousePos.x, mousePos.y);
        }
        transform.position = Vector3.MoveTowards(transform.position, movePosition, Time.deltaTime);
    }
}
