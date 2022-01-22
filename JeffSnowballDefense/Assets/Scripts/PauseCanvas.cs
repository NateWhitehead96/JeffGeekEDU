using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // this allows for moving between scenes or levels

public class PauseCanvas : MonoBehaviour
{
    public void ResumeGame() // this will be a function we call when we hit the resume game button
    {
        Time.timeScale = 1; // make sure time speed/ time scale is back to 1
        gameObject.SetActive(false); // hide the pause canvas from the scene
    }

    public void Replay()
    {
        SceneManager.LoadScene(0); // this will open up our first scene, which is also our play scene
    }
}
