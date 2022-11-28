using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;

public class EndMenu : MonoBehaviour
{
    public float score;
    public Text scoreText;
    public Text playerName;
    public Button saveScoreButton;

    private bool scoreSaved = false;
    private string pattern = "^[a-zA-Z0-9]*$";
    private Match m;
    
    void Start()
    {
        score = ScoreManager.currentScore;
        scoreText.text = "Score: " + score;
        saveScoreButton.GetComponent<Image>().color = Color.gray;
        saveScoreButton.enabled = false;
        scoreSaved = false;
    }

    void Update()
    {
        m = Regex.Match(playerName.text, pattern, RegexOptions.IgnoreCase);
        if (playerName.text != "" && m.Success && !scoreSaved)
        {
            saveScoreButton.GetComponent<Image>().color = Color.green;
            saveScoreButton.enabled = true;
        }
        else
        {
            saveScoreButton.GetComponent<Image>().color = Color.gray;
            saveScoreButton.enabled = false;
        }
    }
    
    public void PlayAgain()
    {
        SceneManager.LoadScene("Map_Scene");
    }
    
    public void Menu()
    {
        SceneManager.LoadScene("menu");
    }

    public void SaveScore()
    {
        ScoreManager.SaveScore(playerName.text, score);
        saveScoreButton.GetComponent<Image>().color = Color.gray;
        saveScoreButton.enabled = false;
        scoreSaved = true;
    }
}
