using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStar : MonoBehaviour
{
    Grid grid;

    private void Start()
    {
        grid = GetComponent<Grid>();
        grid.GetStartingNode(new Vector3Int(1, 0, 0));
        Vector3Int startNodePosition = new Vector3Int(4, 0, 0);

        Node startNode = grid.GetStartingNode(startNodePosition);
        startNode.cube.GetComponent<MeshRenderer>().material.color = Color.red;
    }
}
