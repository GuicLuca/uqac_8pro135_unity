using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    public NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 loc = new Vector3(0,1.5f, 0);
        agent.SetDestination(loc);
        agent.Move(loc);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
