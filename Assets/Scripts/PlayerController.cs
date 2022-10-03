using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private InputActionAsset inputAsset;
    private InputActionMap player;
    public InputAction moveHorizontal;
    public InputAction moveVertical;

    void Awake()
    {
        inputAsset = GetComponent<PlayerInput>().actions;
        player = inputAsset.FindActionMap("Player");
    }
    
    private void OnEnable()
    {
        player.FindAction("Jump").performed += Jump;
        moveHorizontal = player.FindAction("MoveHorizontal");
        moveVertical = player.FindAction("MoveVertical");
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
        Debug.Log(moveHorizontal.ReadValue<float>());
        Debug.Log(moveVertical.ReadValue<float>());
        Debug.Log("\n");
    }

    void Jump(InputAction.CallbackContext obj)
    {
        Debug.Log("Jump!");
    }
}