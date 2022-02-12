using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // this is to help us switch levels

public class RandomLevelPicker : MonoBehaviour
{

    public void RandomLevel()
    {
        int level = Random.Range(0, 3); // pick a random level between 0 and 3
        SceneManager.LoadScene(level); // load that random level
    }
}
