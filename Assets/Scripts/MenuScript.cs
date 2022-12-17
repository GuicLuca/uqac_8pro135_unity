using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1920, 1080, true);
    }

    // Start playing
    public void Play()
    {
        SceneManager.LoadScene("MainScene");
    }

    // Launch settings menu
    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }
    
    // Quit the game
    public void QuitGame()
    {
        Application.Quit();
    }
}
