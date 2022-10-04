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

    private Rigidbody rb;

    public float jumpForce = 1;
    public float speed = 3 ; 


    void Awake()
    {
        inputAsset = GetComponent<PlayerInput>().actions;
        player = inputAsset.FindActionMap("Player");

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
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move(moveHorizontal, moveVertical);
    }

    void Jump(InputAction.CallbackContext obj)
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    void Move(InputAction moveHorizontal, InputAction moveVertical)
    {
        Debug.Log(moveVertical.ReadValue<float>());
        Debug.Log(moveHorizontal.ReadValue<float>());
        rb.AddForce(new Vector3(moveHorizontal.ReadValue<float>(), 0, moveVertical.ReadValue<float>()) * speed, ForceMode.Force);
    }
}