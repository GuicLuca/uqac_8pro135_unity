using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class BounceCounter : MonoBehaviour
{
    public AudioClip bounce;
    private AudioSource audioSource;
    private int bounceCounter;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        bounceCounter = 0;
    }

    void Update()
    {
        if (bounceCounter >= 3)
        {
            SceneManager.LoadScene("level_3");
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        audioSource.PlayOneShot(bounce);
        /*
        if (bounceCounter == 2)
        {
            new WaitForSeconds(1);
        }
        */
        bounceCounter++;
    }
}
