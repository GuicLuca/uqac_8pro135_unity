using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScreenScript : MonoBehaviour
{
    public float score;
    public Text scoreText;
    
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        
        score = ScoreManager.currentScore;
        scoreText.text = "Score: " + score;
    }
    
    public void PlayAgain()
    {
        SceneManager.LoadScene("Space");
    }
    
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
