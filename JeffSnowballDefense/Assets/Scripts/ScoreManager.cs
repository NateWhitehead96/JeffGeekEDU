using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // allows us to access UI classes
using UnityEngine.SceneManagement; // for scene transitions

public class ScoreManager : MonoBehaviour
{
    public Text LivesText; // the reference to the text field that shows our lives
    public Text ScoreText; // the reference to the text fields displaying our score
    public Text WaveText; // the reference to the text field that shows our current wave

    public static int Lives; // our total lives
    public static int Score; // score
    public static int Waves; // current wave
    // Start is called before the first frame update
    void Start()
    {
        // initialize those variables
        Lives = 3;
        Waves = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // update the text fields with our variables
        LivesText.text = "Lives: " + Lives;
        ScoreText.text = "Score: " + Score;
        WaveText.text = "Wave: " + Waves;
        if(Lives <= 0)
        {
            SceneManager.LoadScene(1); // game over scene load
        }
    }
}
