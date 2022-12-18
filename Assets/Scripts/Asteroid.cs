using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private Transform asteroidTransform;
    private Quaternion rotationAngle;
    private Quaternion position;
    private float asteroidXDefaultPosition, asteroidYDefaultPosition, asteroidZDefaultPosition;
    
    public Transform asteroidRoot;
    public float rotationSpeed = 10f;
    public float movementSpeed = 2f;
    
    // Start is called before the first frame update
    void Start()
    {
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
            collision.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
