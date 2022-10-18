using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private InputActionAsset inputAsset;
    private InputActionMap player;
    private InputAction moveHorizontal;
    private InputAction moveVertical;

    private Player sphere;
    private Rigidbody rb;

    void Awake()
    {
        inputAsset = GetComponent<PlayerInput>().actions;
        player = inputAsset.FindActionMap("Player");

        sphere = GetComponent<Player>();
        rb = GetComponent<Rigidbody>();
    }
    
    private void OnEnable()
    {
        player.FindAction("Jump").performed += Jump;
        moveHorizontal = player.FindAction("moveHorizontal");
        moveVertical = player.FindAction("moveVertical");
        player.Enable();
    }
    private void OnDisable()
    {
        player.FindAction("Jump").performed -= Jump;
        player.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        Move(moveHorizontal.ReadValue<float>(), moveVertical.ReadValue<float>());
    }

    void Jump(InputAction.CallbackContext obj)
    {
        rb.AddForce(sphere.CalculateJumpVector(), ForceMode.Impulse);
    }

    void Move(float moveHorizontal, float moveVertical)
    {
        rb.AddForce(sphere.CalculateMovementVector(moveHorizontal, moveVertical), ForceMode.Force);
    }
}