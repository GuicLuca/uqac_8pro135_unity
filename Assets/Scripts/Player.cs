using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 3 ;
    public float jumpForce = 1;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    public void Jump(InputAction.CallbackContext obj)
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    public Vector3 Move(float moveHorizontal, float moveVertical)
    {
        Vector3 movementVector = new Vector3(moveHorizontal, 0, moveVertical) * speed;
        rb.AddForce(movementVector, ForceMode.Force);
        return movementVector;
    }
}