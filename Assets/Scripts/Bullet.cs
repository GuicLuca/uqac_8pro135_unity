using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 250;
    public float lifeTime = 4f;
    public float destroyTime;
    
    private Rigidbody rb;
    private Vector3 forward;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = forward * bulletSpeed;
        if (Time.time >= destroyTime)
        {
            gameObject.SetActive(false);
        }
    }

    public void SetForwardVector(Transform shipTransform)
    {
        forward = shipTransform.forward;
    }
}
