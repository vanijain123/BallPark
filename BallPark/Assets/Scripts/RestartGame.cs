using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    // Restart game
    public void GameRestart()
    {
        Debug.Log("Restart button pressed");
        SceneManager.LoadScene("Scene1");
    }
}
