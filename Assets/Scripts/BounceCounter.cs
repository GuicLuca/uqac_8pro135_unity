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
            StartCoroutine(LoadLevel3());
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (bounceCounter < 3)
        {
            audioSource.PlayOneShot(bounce);
            bounceCounter++;
        }
    }
    private IEnumerator LoadLevel3()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("level_3");
    }

    public int getBounceCounter()
    {
        return this.bounceCounter;
    }
}
