using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingActor : MonoBehaviour
{
    public int rotationX = 2;
    public int rotationY = 0;
    public int rotationZ = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(this.rotationX, this.rotationY, this.rotationZ);
    }
}
