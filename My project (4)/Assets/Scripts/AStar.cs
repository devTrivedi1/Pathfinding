using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AStar : MonoBehaviour
{
    Grid grid;

    [SerializeField] Vector3Int startNodePosition;
    [SerializeField] Vector3Int goalNodePosition;

    List<Node> neighbourNodes = new List<Node>();

    private void Start()
    {
        grid = GetComponent<Grid>();
        Node goalNode = grid.GetNodeBasedOnPosition(goalNodePosition);
        goalNode.cubeObject.GetComponent<MeshRenderer>().material.color = Color.cyan;
        
        while (true)
        {
            neighbourNodes.Clear();

            Vector3Int rightNodePosition = new Vector3Int(1, 0, 0);
            Node rightNode = grid.GetNodeBasedOnPosition(startNodePosition + rightNodePosition);
            if (rightNode != null)
            {
                rightNode.cubeObject.GetComponent<MeshRenderer>().material.color = Color.blue;
                neighbourNodes.Add(rightNode);
            }

            Vector3Int leftNodePosition = new Vector3Int(-1, 0, 0);
            Node leftNode = grid.GetNodeBasedOnPosition(startNodePosition + leftNodePosition);
            if (leftNode != null)
            {
                leftNode.cubeObject.GetComponent<MeshRenderer>().material.color = Color.green;
                neighbourNodes.Add(leftNode);
            }

            Vector3Int topNodePosition = new Vector3Int(0, 0, 1);
            Node topNode = grid.GetNodeBasedOnPosition(startNodePosition + topNodePosition);
            if (topNode != null)
            {
                topNode.cubeObject.GetComponent<MeshRenderer>().material.color = Color.red;
                neighbourNodes.Add(topNode);
            }

            Vector3Int bottomNodePosition = new Vector3Int(0, 0, -1);
            Node bottomNode = grid.GetNodeBasedOnPosition(startNodePosition + bottomNodePosition);
            if (bottomNode != null)
            {
                bottomNode.cubeObject.GetComponent<MeshRenderer>().material.color = Color.yellow;
                neighbourNodes.Add(bottomNode);
            }
            FindFCost();
            break;
        }

    }
    
    void FindFCost()
    {
        for (int i = 0; i < neighbourNodes.Count; i++)
        {
            neighbourNodes[i].GCost = (int)grid.CalculateDistance(startNodePosition, neighbourNodes[i].gridPosition);
            neighbourNodes[i].HCost = (int)grid.CalculateDistance(neighbourNodes[i].gridPosition, goalNodePosition); 
        }
    }

}



