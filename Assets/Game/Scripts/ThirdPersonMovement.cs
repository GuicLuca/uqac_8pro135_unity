using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public Animator animator;
    public int totalTilesToWin = 288;
    public float speed = 50f;

    public Material ColoredMaterial;
    public Material DefaultMaterial;


    public GameObject[] Ennemies;
    
    public float turnSmoothTime = .1f;
    private float turnSmoothVelocity;

    public Text scoreText;
    public Text totalTilesToWinText;
    public Image bloodyEffect;
    
    public int life = 3;
    
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        var bloodyEffectColor = bloodyEffect.color;
        bloodyEffectColor.a = isNearEnemi();
        bloodyEffect.color = bloodyEffectColor;
        
        scoreText.text = "Score: " + ScoreManager.currentScore;
        totalTilesToWinText.text = "Tiles to cover: " + totalTilesToWin;
        
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= .1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDirection.normalized * speed * Time.deltaTime);
        }

        if (horizontal != 0 || vertical != 0)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
        
        Debug.Log("Life = " + life);
        
        checkTheGround();
        CheckLife();

        /*
        if (Input.GetKeyDown(KeyCode.T))
            SceneManager.LoadScene("end_game");
        */
    }
    
    private void checkTheGround()
    {
        /*
         * Create the hit object
         * This will later hold the data for the hit
         * (location, collided collider etc.)
         */
        RaycastHit hit;
        // The ray length.
        float distance = 10.0f;

        /*
         * Cast a raycast.
         * If it hits something:
         */
        if (Physics.Raycast(transform.position, Vector3.down, out hit, distance))
        {
            GameObject obj;
            obj = hit.collider.gameObject; //Store reference of target to a variable
            Renderer objRenderer = obj.GetComponent<Renderer>();
            
            if (objRenderer.material.name.Contains(DefaultMaterial.name))
            {
                Debug.Log("Should change the til material");
                objRenderer.material = ColoredMaterial; //Set target to new material
                // increase the score and decreas the total tile to color
                ScoreManager.currentScore += 10;
                totalTilesToWin -= 1;

                if (totalTilesToWin == 0)
                {
                    ScoreManager.currentScore += 100;
                    Debug.Log("LA PARTIE EST FINI");
                    SceneManager.LoadScene("end_game");
                }
            }
        }
    }

    private void CheckLife()
    {
        if (life == 0)
        {
            SceneManager.LoadScene("end_game");
        }
        
        if (this.transform.position.y > 50.0f)
        {
            Vector3 resetPosition = new Vector3(this.transform.position.x, 3.1f, 0); 
            Debug.Log("Reset Position");
            // this.transform.position = resetPosition;
            this.transform.position = new Vector3(385.0f, 3.1f, 955.5f);
        }
    }

    private float isNearEnemi()
    {
        foreach (var enemi in Ennemies)
        {
            if (Vector3.Distance(enemi.transform.position,transform.position) <= 200)
            {
                return 1 - (Vector3.Distance(enemi.transform.position,transform.position) / 200);
            }
        }

        return 0;
    }
}
