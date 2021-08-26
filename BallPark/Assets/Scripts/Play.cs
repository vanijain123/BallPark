using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    // Play game
    public void GameStart()
    {
        Debug.Log("Restart button pressed");
        SceneManager.LoadScene("Scene1");
    }
}
