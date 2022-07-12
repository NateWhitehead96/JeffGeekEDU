using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hospital : MonoBehaviour
{
    public int level; // what level the hospital is 
    public List<GameObject> characters; // a list of all the character in the hospital
    public float timer; // count seconds 
    // Start is called before the first frame update
    void Start()
    {
        characters = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (characters.Count == 0) return; // if we have no people in the hospital, dont run any more code

        if (timer >= 1) 
        {
            if(characters[0].GetComponent<PlayerUnit>().health >= 10) // if the character is at max hp
            {
                characters.RemoveAt(0); // remove from the list
            }
            // if the character was injured and healed to 8 hp, then remove
            if(characters[0].GetComponent<PlayerUnit>().injured == true && characters[0].GetComponent<PlayerUnit>().health >= 8)
            {
                characters.RemoveAt(0); // remove from the list
            }
            characters[0].GetComponent<PlayerUnit>().health++; // heal 1 hp
            timer = 0; // reset timer
        }
        timer += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerUnit>()) // when the character enters the hospital
        {
            characters.Add(collision.gameObject); // add the character to our list
        }
    }
}
