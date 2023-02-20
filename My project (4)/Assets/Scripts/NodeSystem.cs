using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class NodeSystem
{
    public Vector3 gridPos, worldPos;

    int gCost, hCost, fCost;

    Node parent;

    bool isWalkable;

    public NodeSystem (Vector3 gridPos, Vector3 worldPos)
    {
        this.gridPos = gridPos;
        this.worldPos = worldPos;
       
    }   
}
