using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static float currentScore = 0;
    public static Dictionary<string, float> leaderboard = new Dictionary<string, float>();

    public static void SaveScore(string name, float score)
    {
        leaderboard = StringToDictionary(PlayerPrefs.GetString("leaderboard"));
        string key = $"{name}-{DateTime.Now}";
        leaderboard.Add(key, score);
        PlayerPrefs.SetString("leaderboard", DictionaryToString(leaderboard));
    }

    public static string DictionaryToString(Dictionary<string, float> dict)
    {
        string str = "";
        foreach (var elem in dict)
        {
            str += $"{elem.Key}_{elem.Value}*";
        }

        return str;
    }
    
    public static Dictionary<string, float> StringToDictionary(string str)
    {
        Dictionary<string, float> dict = new Dictionary<string, float>();
        var scores = str.Split('*');
        for (int i = 0; i < scores.Length - 1; i++)
        {
            dict.Add(scores[i].Split('_')[0], float.Parse(scores[i].Split('_')[1]));
        }
        return dict;
    }
}
