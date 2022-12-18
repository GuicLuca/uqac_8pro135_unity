using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text score;
    public static float currentScore = 0;

    void Start()
    {
        score.text = currentScore.ToString();
    }
    
    public void IncrementScore()
    {
        currentScore++;
        score.text = currentScore.ToString();
    }
}
