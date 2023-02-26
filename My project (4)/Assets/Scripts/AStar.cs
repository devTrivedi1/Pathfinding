using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStar : MonoBehaviour
{
    Grid grid;

    [SerializeField] Vector3Int startNodePosition;

    private void Start()
    {
        grid = GetComponent<Grid>();

        Vector3Int rightNodePosition = new Vector3Int(1, 0, 0);
        Node rightNode = grid.GetStartingNode(startNodePosition + rightNodePosition);
        if (rightNode != null)
        {
            rightNode.cube.GetComponent<MeshRenderer>().material.color = Color.blue;
        }

        Vector3Int leftNodePosition = new Vector3Int(-1, 0, 0);
        Node leftNode = grid.GetStartingNode(startNodePosition + leftNodePosition);
        if (leftNode != null)
        {

            leftNode.cube.GetComponent<MeshRenderer>().material.color = Color.green;
        }

        Vector3Int topNodePosition = new Vector3Int(0, 0, 1);
        Node topNode = grid.GetStartingNode(startNodePosition + topNodePosition);
        if (topNode != null)
        {

            topNode.cube.GetComponent<MeshRenderer>().material.color = Color.red;
        }

        Vector3Int bottomNodePosition = new Vector3Int(0, 0, -1);
        Node bottomNode = grid.GetStartingNode(startNodePosition + bottomNodePosition);
        if (bottomNode != null)
        {

            bottomNode.cube.GetComponent<MeshRenderer>().material.color = Color.yellow;
        }

    }
}
