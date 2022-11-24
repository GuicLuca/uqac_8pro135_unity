using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;

    [SerializeField] public GameObject player;
    [SerializeField] public Boolean Follow;
    [SerializeField] public Boolean Preshot;
    [SerializeField] public Boolean Random;
    
    private Action myFunAction = null;
    
    private static float val = 200;
    private float preshotValX = val;
    private float preshotValZ = val;
    private bool DestinationSuccess;
    private Vector3 randomDestination;
    

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

    // Update is called once per frame
    void Update()
    {
        if (myFunAction == RandomPlayer)
        {
            if (DestinationSuccess)
            {
                myFunAction();
                Debug.Log("Function is Random & destination is Success");
            }
            else
            {
                IsDestinationSuccess(randomDestination);
            }
        }
        else{
            myFunAction();
        }
    }

    public void FollowPlayer()
    {
        // Debug.Log("Follow Player Function Called", null);
        navMeshAgent.SetDestination(player.transform.position);
    }

    public void PreshotPlayer()
    {
        // Debug.Log("Preshot Player Function Called", null);
        float velX = transform.forward.x * preshotValX ;
        float velZ = transform.forward.z * preshotValZ ;
        Vector3 preshot = new Vector3(velX, player.transform.localPosition.y, velZ);
        navMeshAgent.SetDestination(preshot);
    }

    public void RandomPlayer()
    {
        randomDestination = GetRandomGameBoardLocation();
        navMeshAgent.SetDestination(randomDestination);
        DestinationSuccess = false;
        // Debug.Log("Random Function Called", null);
        Debug.Log(randomDestination.ToString());
    }
    
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

    private bool IsDestinationSuccess(Vector3 Destination)
    {
        bool ret = false;
        float distance = Vector3.Distance(navMeshAgent.transform.position, Destination);
        
        if (distance < 100)
        {
            DestinationSuccess = true;
            ret = true;
        }
        
        Debug.Log("On Function :: IsDestinationSuccess");
        return ret;
    }
}
