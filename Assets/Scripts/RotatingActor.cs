using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingActor : MonoBehaviour
{
    public int rotationX = 1;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(this.rotationX, 0, 0);
    }
}
