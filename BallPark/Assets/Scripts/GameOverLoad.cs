using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverLoad : MonoBehaviour
{
    public TextMeshProUGUI healthGUI;
    public TextMeshProUGUI timerGUI;

    private string health;
    private string time;

    void Start()
    {
        //Uses health and time values from previous scene
        health = PlayerPrefs.GetString("health");
        time = PlayerPrefs.GetString("time");
        healthGUI.text = "Health: " + health;
        timerGUI.text = "Time taken: " + time + " seconds";
    }
    // COMS 4156 homework 0
}
