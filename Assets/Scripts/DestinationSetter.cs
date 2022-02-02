using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class DestinationSetter : MonoBehaviour {
    void Start() {
        GetComponent<AIDestinationSetter>().target = GameObject.Find("Corovan").transform;
    }
}