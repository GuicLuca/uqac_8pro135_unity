using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.AI;
using Vector3 = UnityEngine.Vector3;

public class AIController : MonoBehaviour
{ 
//----------------------------------------------- Initialize
    
    //Define in Unity Editor the NavMeshAgent of AI instance
    public NavMeshAgent navMeshAgent;

    //Define in Unity Editor which Actor/Player to target
    [SerializeField] public GameObject player;
    private ThirdPersonMovement playerScript;
    
    //Define in Unity Editor the ghost in follow mode
    [SerializeField] public GameObject ghost;
    
    /*This SerializeField allows to develop different state machine in one script
     In Unity Editor, check the behavior you want the AI get*/
    [SerializeField] public Boolean Follow;
    [SerializeField] public Boolean Preshot;
    [SerializeField] public Boolean Random;
    
    //This pointer contains the behavior of the AI
    private Action myFunAction = null;
    
    //Theses values are the offset of the pre-shot behavior
    private static float val = 200;
    private float preshotValX = val;
    private float preshotValZ = val;
    
    //DestinationSuccess is a security that allows to check if the AI has reached its destination
    private bool DestinationSuccess;
    private Vector3 randomDestination;
    
//----------------------------------------------- Function
    void Start()
    {
        DestinationSuccess = true;
        
        if (Follow)
        {
            myFunAction = FollowPlayer;
        }
        else if (Preshot)
        {
            myFunAction = PreshotPlayer;
        }
        else
        {
            myFunAction = RandomPlayer;
        }
        
    }

    /// <summary>
    /// Update is called once per frame and will start the behavior
    /// If AI behavior is Random, we will check if AI reached its destination
    /// If false, wait until AI reached its destination
    /// </summary>
    void Update()
    {
        if (myFunAction == RandomPlayer)
        {
            if (DestinationSuccess)
            {
                myFunAction();
            }
            else
            {
                IsDestinationSuccess(randomDestination);
            }
        }
        else{
            myFunAction();
        }
        
        IsGhostCloseToMe();
    }
    
//----------------------------------------------- Ghost Behavior
    
    /// <summary>
    /// Set the next destination at player location
    /// </summary>
    public void FollowPlayer()
    {
        // Debug.Log("Follow Player Function Called", null);
        navMeshAgent.SetDestination(player.transform.position);
    }

    /// <summary>
    /// This function should anticipate the next forward location of the player in order to pre-shot him
    /// </summary>
    public void PreshotPlayer()
    {
        float velX = transform.forward.x * preshotValX ;
        float velZ = transform.forward.z * preshotValZ ;
        Vector3 preshot = new Vector3(velX, player.transform.localPosition.y, velZ);
        navMeshAgent.SetDestination(preshot);
    }

    /// <summary>
    /// This Function will get an Vector3 from GetRandomGameBoardLocation(), 
    /// The navMeshAgent will move to this random location
    /// </summary>
    public void RandomPlayer()
    {
        randomDestination = GetRandomGameBoardLocation();
        navMeshAgent.SetDestination(randomDestination);
        DestinationSuccess = false;
    }
    
    /// <summary>
    /// Search in the NavigationMesh System a random point to reach
    /// </summary>
    /// <returns>Vector3 point : the Random point in the NavigationMesh Scene</returns>
    private Vector3 GetRandomGameBoardLocation()
    {
        NavMeshTriangulation navMeshData = NavMesh.CalculateTriangulation();
 
        int maxIndices = navMeshData.indices.Length - 3;
 
        // pick the first indice of a random triangle in the nav mesh
        int firstVertexSelected = UnityEngine.Random.Range(0, maxIndices);
        int secondVertexSelected = UnityEngine.Random.Range(0, maxIndices);
 
        // spawn on verticies
        Vector3 point = navMeshData.vertices[navMeshData.indices[firstVertexSelected]];
 
        Vector3 firstVertexPosition = navMeshData.vertices[navMeshData.indices[firstVertexSelected]];
        Vector3 secondVertexPosition = navMeshData.vertices[navMeshData.indices[secondVertexSelected]];
 
        // eliminate points that share a similar X or Z position to stop spawining in square grid line formations
        if ((int)firstVertexPosition.x == (int)secondVertexPosition.x || (int)firstVertexPosition.z == (int)secondVertexPosition.z)
        {
            point = GetRandomGameBoardLocation(); // re-roll a position - I'm not happy with this recursion it could be better
        }
        else
        {
            // select a random point on it
            point = Vector3.Lerp(firstVertexPosition, secondVertexPosition, UnityEngine.Random.Range(0.05f, 0.95f));
        }
 
        return point;
    }
 
    /// <summary>
    /// This function will allow us to know if our AI reached the Destination
    /// </summary>
    /// <param name="Destination">It is the Destination for the AI to reach</param>
    /// <returns>Return a boolean : if the destination is reached ? true : False</returns>
    private bool IsDestinationSuccess(Vector3 Destination)
    {
        bool ret = false;
        float distance = Vector3.Distance(navMeshAgent.transform.position, Destination);
        
        if (distance < 100)
        {
            DestinationSuccess = true;
            ret = true;
        }
        return ret;
    }
    
//----------------------------------------------- Collision with Player

    private void OnTriggerEnter(Collider other)
    {
        GameObject playerObject = GameObject.Find("Ninja");
        if (playerObject != null)
        {
            playerScript = player.GetComponent<ThirdPersonMovement>();
            if (playerScript.life != 0)
            {
                playerScript.life -= 1;
                
                this.transform.position = GetRandomGameBoardLocation();
                Debug.Log("Player life -1");
            }
            
        }
        
        
    }
    
//----------------------------------------------- Collision with Ghost

    private void IsGhostCloseToMe()
    {
        float minDistance = 75.0f;
        float dist = Vector3.Distance(ghost.transform.position, this.transform.position);
        
        if (dist < minDistance)
        {
            this.transform.position = GetRandomGameBoardLocation();
            Debug.Log("Ghost TP");
        }
    }

}


