using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public float score;
    public Text scoreText;
    public Text playerName;
    public Button saveScoreButton;
    
    void Start()
    {
        score = ScoreManager.currentScore;
        scoreText.text = "Score: " + score;
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
        if (playerName.text != "")
        {
            ScoreManager.SaveScore(playerName.text, score);
            saveScoreButton.enabled = false;
            saveScoreButton.GetComponent<Image>().color = Color.gray;
        }
    }
}
