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

    public List<GameObject> EnemiesInRange; // we have a list of all the enemies near our character
    public Weapon weapon; // the weapon our character is holding
    public bool attacking; // to know if this character is currently attacking or not
    public int health; // how much health the player

    public bool injured; // tell us if this unit is hurt from battle
    // Start is called before the first frame update
    void Start()
    {
        movePosition = transform.position;
        sprite = GetComponent<SpriteRenderer>(); // make sure our sprite is the right one
        EnemiesInRange = new List<GameObject>(); // make sure the enemy list is a fresh list
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
        float distance = Vector3.Distance(transform.position, movePosition); // calculating the distance from character pos to move pos
        if(distance < 0.1f && EnemiesInRange.Count != 0) // if the character is at it's destination and we have enemies nearby, we attack
        {
            if(attacking == false)
            {
                StartCoroutine(AttackEnemy());
            }
        }
        if(health <= 5)
        {
            injured = true; // only when we take enough damage, our character becomes injured
        }
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator AttackEnemy()
    {
        attacking = true; // we're now attacking the enemy
        // deal damage to enemy
        EnemiesInRange[0].GetComponent<Enemy>().health -= weapon.damage; //find the enemies health, subtract our weapon damage
        yield return new WaitForSeconds(weapon.attackSpeed); // make us wait for however long the attack speed is
        attacking = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
        {
            movePosition = transform.position; // this will stop the player from moving when it collides with an enemy
        }
    }
}