using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Node
{
    public Vector3 gridPos, worldPos;

    int gCost, hCost, fCost;

    bool isWalkable;

    public GameObject cube;

    public Node(Vector3 gridPos, Vector3 worldPos)
    {
        this.gridPos = gridPos;
        this.worldPos = worldPos;
    }



}
