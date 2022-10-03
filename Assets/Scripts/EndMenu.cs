using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public void PlayAgain()
    {
        SceneManager.LoadScene("level_1");
    }
    
    public void Menu()
    {
        SceneManager.LoadScene("menu");
    }
}
