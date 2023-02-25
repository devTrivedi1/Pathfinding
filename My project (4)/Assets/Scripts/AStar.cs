using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStar : MonoBehaviour
{
    Grid grid;

    private void Start()
    {
        grid = GetComponent<Grid>();
        Vector3Int startNodePosition = new Vector3Int(3, 0, 2);

        Node startNode = grid.GetStartingNode(startNodePosition);

        Vector3Int leftNodePosition = new Vector3Int(-1, 0, 0);
        Node leftNode = grid.GetStartingNode(startNodePosition + leftNodePosition);
        leftNode.cube.GetComponent<MeshRenderer>().material.color = Color.green;

        Vector3Int rightNodePosition = new Vector3Int(1, 0, 0);
        Node rightNode = grid.GetStartingNode(startNodePosition + rightNodePosition);
        rightNode.cube.GetComponent<MeshRenderer>().material.color = Color.blue;

        Vector3Int bottomNodePosition = new Vector3Int(0, 0, -1);
        Node bottomNode = grid.GetStartingNode(startNodePosition + bottomNodePosition);
        bottomNode.cube.GetComponent<MeshRenderer>().material.color = Color.yellow;

        Vector3Int topNodePosition = new Vector3Int(0, 0, 1);
        Node topNode = grid.GetStartingNode(startNodePosition + topNodePosition);
        topNode.cube.GetComponent<MeshRenderer>().material.color = Color.red;

    }
}
