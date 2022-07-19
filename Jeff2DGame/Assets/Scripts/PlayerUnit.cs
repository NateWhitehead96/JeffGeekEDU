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
    public float speed; // how fast the unit moves
    public float clickTime; // cool down timer for movement
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
        if (Input.GetMouseButtonDown(1) && selected == true && clickTime >= 3) 
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            movePosition = new Vector3(mousePos.x, mousePos.y);
        }
        transform.position = Vector3.MoveTowards(transform.position, movePosition, speed * Time.deltaTime);
        float distance = Vector3.Distance(transform.position, movePosition); // calculating the distance from character pos to move pos
        //if(distance < 0.1f && EnemiesInRange.Count != 0) // if the character is at it's destination and we have enemies nearby, we attack
        //{
        //    if(attacking == true)
        //    {
        //        StartCoroutine(AttackEnemy());
        //    }
        //}
        if(distance > 0.1f) // distance is > 0.1f we are in motion towards our move position
        {
            clickTime = 0; // resetting the move cool down
        }

        if(transform.position == movePosition) // when our unit gets to the move position start the cooldown
        {
            clickTime += Time.deltaTime;
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

    public void AttackEnemy()
    {
        //attacking = false; // make sure this only happens once
        // deal damage to enemy
        EnemiesInRange[0].GetComponent<Enemy>().health -= weapon.damage; //find the enemies health, subtract our weapon damage
        if (EnemiesInRange.Count == 0) // we run out of enemies to kill, stop attacking
        {
            CancelInvoke();
        }
        //yield return new WaitForSeconds(weapon.attackSpeed); // make us wait for however long the attack speed is
        //attacking = true; // if we're still fighting the enemy attacking goes back to true
        //if(EnemiesInRange[0] == null) // if we have no more enemies to fight
        //{
        //    attacking = false;
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
        {
            movePosition = transform.position; // this will stop the player from moving when it collides with an enemy
            //attacking = true; // touched an enemy, now is attacking
            InvokeRepeating("AttackEnemy", 1, weapon.attackSpeed);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
        {
            CancelInvoke(); // stop attacking if enemy leaves our area or we kill it
        }
    }
}
