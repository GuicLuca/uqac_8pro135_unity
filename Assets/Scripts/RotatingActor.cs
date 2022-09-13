using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingActor : MonoBehaviour
{
    public float PitchValue {get; set;}
    public float YawValue {get; set;}
    public float RollValue {get; set;}
    
    // Start is called before the first frame update
    void Start()
    {
        PitchValue = 0;
        YawValue = 0;
        RollValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(PitchValue, YawValue, RollValue);
    }
}
