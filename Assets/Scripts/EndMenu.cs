using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public void PlayAgain()
    {
        SceneManager.LoadScene("Level1");
    }
    
    public void Menu()
    {
        SceneManager.LoadScene("menu");
    }

    public void Shaders()
    {
        SceneManager.LoadScene("shaders");
    }
}
