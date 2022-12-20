using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBar;
    public Image[] healthPoints;
    
    [SerializeField]
    public Canvas canvas;

    private float health;

    [SerializeField]
    private float maxHealth = 3;

    private void Start()
    {
        health = maxHealth;
        canvas.gameObject.SetActive(false);
    }

    private void Update()
    {
        HealthBarFiller();
        ColorChanger();
    }

    private void HealthBarFiller()
    {
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, (health / maxHealth), 0);

        for (int i = 0; i < healthPoints.Length; i++)
        {
            healthPoints[i].enabled = !DisplayHealthPoint(health, i);
        }
    }
    private void ColorChanger()
    {
        Color healthColor = Color.Lerp(Color.red, Color.green, (health / maxHealth));
        healthBar.color = healthColor;
    }

    private static bool DisplayHealthPoint(float health, int pointNumber)
    {
        return ((pointNumber * 10) >= health);
    }

    public void Damage(float damagePoints)
    {
        canvas.gameObject.SetActive(true);

        StartCoroutine(nameof(HideCanvasAfterDelay));
        health -= damagePoints;
        
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator HideCanvasAfterDelay()
    {
        yield return new WaitForSeconds(5);
        canvas.gameObject.SetActive(false);
    }
}
