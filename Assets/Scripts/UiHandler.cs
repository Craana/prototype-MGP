using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] scoreCounter scorecounter;
    [SerializeField] private TMP_Text timeText;
    private float startTime;

    private void Start()
    {
        InvokeRepeating("increaseScore", 0f, 5f);
    }

    void Update()
    {
        DisplayScore();   
        DisplayTime();

    }

    void DisplayScore()
    {
        scoreText.text = "score: " + scorecounter.informScore().ToString();
    }


    void DisplayTime()
    {
        float t = Time.time - startTime;
        
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("F2");

        timeText.text = minutes + ":" + seconds;
    }

    void increaseScore()
    {
        scorecounter.AddScore();
    } 
}
