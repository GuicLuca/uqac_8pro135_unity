using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static float currentScore = 1222;

    public static Dictionary<string, float> leaderboard = new Dictionary<string, float>
    {
        {"Lucas", 320},
        {"Marc", 250},
        {"Ethan", 300},
    };

    public static void SaveScore(string name, float score)
    {
        string key = $"{name}-{DateTime.Now}";
        leaderboard.Add(key, score);
    }
}
