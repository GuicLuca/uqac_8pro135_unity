using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class MenuScript : MonoBehaviour
{
    public Text leaderboardText;
    
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1920, 1080, true);
        
        // Display the 3 best scores in leaderboard
        Dictionary<string, float> unsortedLeaderboard = ScoreManager.StringToDictionary(PlayerPrefs.GetString("leaderboard"));
        var sortedLeaderboard = SortLeaderboard(unsortedLeaderboard);
        int i = 1;
        foreach (var leaderboardItem in sortedLeaderboard.Take(3))
        {
            string nameToDisplay = leaderboardItem.Key.Split('-')[0].ToUpper();
            leaderboardText.text += $"\n #{i}\t \t{nameToDisplay}\t \t{leaderboardItem.Value}";
            i++;
        }
    }

    public static IOrderedEnumerable<System.Collections.Generic.KeyValuePair<string,float>> SortLeaderboard(Dictionary<string, float> unsortedLeaderboard)
    {   
        var sortedLeaderboard = from entry in unsortedLeaderboard orderby entry.Value descending select entry;
        return sortedLeaderboard;
    }

    // Start playing
    public void Play()
    {
        SceneManager.LoadScene("Map_Scene");
    }

    // Launch settings menu
    public void Settings()
    {
        SceneManager.LoadScene("settings");
    }
    
    // Quit the game
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }
}
