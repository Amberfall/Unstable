using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string playerName = (GetComponent<Rigidbody2D>().worldCenterOfMass.x < 0) ? "Dream Player" : "Waking Player";
        GetComponent<AIDestinationSetter>().target = GameObject.Find(playerName).transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
