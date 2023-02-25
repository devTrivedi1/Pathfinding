using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Node
{
    public Vector3 gridPosition;
    public Vector3 worldPosition;

    public int gCost;
    public int hCost;

    bool isWalkable;

    public GameObject cube;

    public Node(Vector3 gridPos, Vector3 worldPos)
    {
        this.gridPosition = gridPos;
        this.worldPosition = worldPos;
    }

    public int fCost
    {
        get { return gCost + hCost; }

    }
}
