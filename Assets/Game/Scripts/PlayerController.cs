using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private InputActionAsset inputAsset;
    private InputActionMap playerInputs;
    private InputAction moveHorizontal;
    private InputAction moveVertical;
    
    public float speed = 5;
    public float rotationSpeed = 720;

    private Animator animator;

    void Awake()
    {
        inputAsset = GetComponent<PlayerInput>().actions;
        playerInputs = inputAsset.FindActionMap("Player");
        animator = GetComponent<Animator>();
    }
    
    private void OnEnable()
    {
        moveHorizontal = playerInputs.FindAction("moveHorizontal");
        moveVertical = playerInputs.FindAction("moveVertical");
        playerInputs.Enable();
    }
    private void OnDisable()
    {
        playerInputs.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movementDirection = new Vector3(moveHorizontal.ReadValue<float>(), 0, moveVertical.ReadValue<float>());
        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * speed;
        movementDirection.Normalize();
        Vector3 velocity = movementDirection * magnitude;
        transform.Translate(velocity * Time.deltaTime, Space.World);
        
        if (movementDirection != Vector3.zero)
        {
            animator.SetBool("isMoving", true);
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }
}