using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleproter : MonoBehaviour
{
    public GameObject Player;
    public GameObject Destination;
    // Start is called before the first frame update

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("TP triggerd");
        Player.transform.position = Destination.transform.position;
    }
}
