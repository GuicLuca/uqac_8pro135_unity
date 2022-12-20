using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Asteroid : MonoBehaviour
{
    public Transform asteroidRoot;
    public float rotationSpeed = 10f;
    public float movementSpeed = 5f;
    public ParticleSystem explosion;

    public Transform ship;
    public AudioSource audioSource;

    public ScoreManager scoreManager;
    
    private Transform asteroidTransform;
    private Quaternion rotationAngle;
    private Quaternion position;
    private float asteroidXDefaultPosition, asteroidYDefaultPosition, asteroidZDefaultPosition;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
        asteroidRoot = GetComponent<Transform>();
        asteroidXDefaultPosition = asteroidRoot.position.x;
        asteroidYDefaultPosition = asteroidRoot.position.y;
        asteroidZDefaultPosition = asteroidRoot.position.z;
        position.x = transform.position.x;
        position.y = transform.position.y;
        position.z = transform.position.z;
        rotationAngle = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        asteroidTransform = asteroidRoot.transform;
        
        // Update rotation
        rotationAngle.x += rotationSpeed * Time.deltaTime;
        asteroidTransform.localEulerAngles = new Vector3(rotationAngle.x, 0, 0);
        
        // Update position
        position.x += movementSpeed * Time.deltaTime;
        asteroidTransform.position = new Vector3(position.x, asteroidYDefaultPosition, asteroidZDefaultPosition);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            AudioSource.PlayClipAtPoint(audioSource.clip, ship.position);
            
            collision.gameObject.SetActive(false);
            Destroy(gameObject);
            
            Instantiate(explosion, transform.position, Quaternion.identity);

            scoreManager.GetComponent<ScoreManager>().IncrementScore();
        }
    }
}
