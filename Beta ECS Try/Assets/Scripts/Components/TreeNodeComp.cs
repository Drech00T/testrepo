using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class TreeNodeComp : MonoBehaviour {
    public List<GameObject> nodesInRange;
    public float linkDistance;
    public int nodeID;
    public GameObject linkPreFab;
}
