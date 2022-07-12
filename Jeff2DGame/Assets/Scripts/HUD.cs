using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // for access to UI things and stuffs

public class HUD : MonoBehaviour
{
    public GameObject[] characters; // an array (list) of all of our playable characters
    public Slider[] healthBars; // each character gets its own health bar
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < characters.Length; i++) // this for loop, loops through all of our character
        {
            healthBars[i].maxValue = characters[i].GetComponent<PlayerUnit>().health; // set the max hp of each bar to be the char hp
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < characters.Length; i++) // this for loop, loops through all of our character
        {
            healthBars[i].value = characters[i].GetComponent<PlayerUnit>().health; // set the value of the bar to be characters hp
        }
    }
}
