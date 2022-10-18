using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float speed = 3 ;
    public float jumpForce = 1;
    
    public Vector3 CalculateJumpVector()
    {
        Vector3 jumpVector = Vector3.up * jumpForce;
        return jumpVector;
    }

    public Vector3 CalculateMovementVector(float moveHorizontal, float moveVertical)
    {
        Vector3 movementVector = new Vector3(moveHorizontal, 0, moveVertical) * speed;
        return movementVector;
    }
}