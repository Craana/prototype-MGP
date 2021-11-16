using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] scoreCounter scorecounter;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "score: " + scorecounter.informScore().ToString();
    }
}
