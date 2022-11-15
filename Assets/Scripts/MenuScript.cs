using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1920, 1080, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Start playing
    public void Play()
    {
        SceneManager.LoadScene("Level1");
    }
    
    // Show shaders demo
    public void Shaders()
    {
        SceneManager.LoadScene("shaders");
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
