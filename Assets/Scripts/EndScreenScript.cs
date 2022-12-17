using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public float score;
    public Text scoreText;
    
    void Start()
    {
        score = ScoreManager.currentScore;
        scoreText.text = "Score: " + score;
    }
    
    public void PlayAgain()
    {
        SceneManager.LoadScene("MainScene");
    }
    
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
