using UnityEngine;

public class Clicker : MonoBehaviour
{
    public int count = 0;
    public TMPro.TextMeshProUGUI counter;

    void Update()
    {
        counter.text = "Clicked : "+ count;
    }
    
    public void OnClick()
    {
        count++;
    }
}
