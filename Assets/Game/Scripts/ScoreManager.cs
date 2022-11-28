using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static float currentScore = 0;
    public static Leaderboard C_Leaderboard = new Leaderboard();

    public static void SaveScore(string name, float score)
    {
        string key = $"{name}-{DateTime.Now}";
        C_Leaderboard.leaderboard.Add(key, score);
        PlayerPrefs.SetString("leaderboard", JsonUtility.ToJson(C_Leaderboard));
    }
}
