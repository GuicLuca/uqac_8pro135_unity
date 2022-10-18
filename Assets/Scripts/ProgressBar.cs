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
    
    private bool isTesting = true;
    
    // Start is called before the first frame update
    void Start()
    {
        totalTime = 3.0f;
        currentTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        isTesting = false;
        GetCurrentFill();
        currentTime += Time.deltaTime;
        if (currentTime >= 3)
        {
            SceneManager.LoadScene("level_2");
        }
    }

    public float GetCurrentFill()
    {
        float fillAmount = 1 - (currentTime / totalTime);
        if(!isTesting)
            mask.fillAmount = fillAmount;
        return fillAmount;
    }
}
