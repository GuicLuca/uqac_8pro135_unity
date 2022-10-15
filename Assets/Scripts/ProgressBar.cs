using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public float totalTime;
    public float currentTime;
    public Image mask;
    
    // Start is called before the first frame update
    void Start()
    {
        totalTime = 3.0f;
        currentTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        GetCurrentFill();
        currentTime += Time.deltaTime;
        if (currentTime >= 3)
        {
            SceneManager.LoadScene("level_2");
        }
    }

    void GetCurrentFill()
    {
        float fillAmount = 1 - (currentTime / totalTime);
        mask.fillAmount = fillAmount;
    }
}
