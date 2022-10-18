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

    void Awake()
    {
        inputAsset = GetComponent<PlayerInput>().actions;
        player = inputAsset.FindActionMap("Player");

        sphere = GetComponent<Player>();
    }
    
    private void OnEnable()
    {
        player.FindAction("Jump").performed += sphere.Jump;
        moveHorizontal = player.FindAction("moveHorizontal");
        moveVertical = player.FindAction("moveVertical");
        player.Enable();
    }
    private void OnDisable()
    {
        player.FindAction("Jump").performed -= sphere.Jump;
        player.Disable();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sphere.Move(moveHorizontal.ReadValue<float>(), moveVertical.ReadValue<float>());
    }

    
}