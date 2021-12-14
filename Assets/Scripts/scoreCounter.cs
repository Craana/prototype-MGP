using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreCounter : MonoBehaviour
{

    int score;

    // Update is called once per frame
    void Update()
    {
       
    }

    public int informScore()
    {
        return score;
    }

    public void AddScore()
    {
        score++;
    }


}
