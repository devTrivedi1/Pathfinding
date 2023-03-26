using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;

public class AStar : MonoBehaviour
{
    Grid grid;

    List<Node> neighbourNodes = new List<Node>();
    List<Node> openList = new List<Node>();
    List<Node> closedList = new List<Node>();
    /*    List<Node> finalPath = new List<Node>();
    */
    Node startNode;
    Node goalNode;
    Node currentNode;

    bool pathFound;

    int algoVersion;
    private void Awake()
    {
        grid = GetComponent<Grid>();
    }

    public bool InitializeAstar(Vector3Int startNodePosition, Vector3Int goalNodePosition, out List<Node> finalPath)
    {
        openList = new List<Node>();
        while (true)
        {

            if (openList.Count <= 0)
            {
                finalPath = null;
                return false;
            }
            grid.ClearGrid();
            FindFCost(startNodePosition, goalNodePosition);
            SetNewNeighbors(startNodePosition, goalNodePosition);
            openList.Add(startNode);
            if (!pathFound)
            {
                CreateNeighbors(out finalPath);
            }
        }
    }

    void CreateNeighbors(out List<Node> finalPath)
    {
        openList.Sort();
        currentNode = openList[0];
        openList.RemoveAt(0);

        currentNode.Cube.GetComponent<MeshRenderer>().material.color = Color.blue;

        closedList.Add(currentNode);
        neighbourNodes.Clear();

        Vector3Int rightNodePosition = new Vector3Int(1, 0, 0);
        if (currentNode.gridPosition.x + 1 < grid.gridSize.x)
        {
            Node rightNode = grid.GetNodeBasedOnPosition(currentNode.gridPosition + rightNodePosition);
            neighbourNodes.Add(rightNode);
        }

        Vector3Int leftNodePosition = new Vector3Int(-1, 0, 0);
        if (currentNode.gridPosition.x - 1 >= 0)
        {
            Node leftNode = grid.GetNodeBasedOnPosition(currentNode.gridPosition + leftNodePosition);
            neighbourNodes.Add(leftNode);
        }

        Vector3Int topNodePosition = new Vector3Int(0, 0, 1);
        if (currentNode.gridPosition.z + 1 < grid.gridSize.z)
        {
            Node topNode = grid.GetNodeBasedOnPosition(currentNode.gridPosition + topNodePosition);
            neighbourNodes.Add(topNode);
        }

        Vector3Int bottomNodePosition = new Vector3Int(0, 0, -1);
        if (currentNode.gridPosition.z - 1 >= 0)
        {
            Node bottomNode = grid.GetNodeBasedOnPosition(currentNode.gridPosition + bottomNodePosition);
            neighbourNodes.Add(bottomNode);
        }
        CalculateNeighborNodes(out finalPath);
    }

    void CalculateNeighborNodes(out List<Node> finalPath)
    {
        finalPath = new List<Node>();
        for (int i = 0; i < neighbourNodes.Count; i++)
        {
            neighbourNodes[i].cubeObject.GetComponent<MeshRenderer>().material.color = Color.green;

            if (neighbourNodes[i] == goalNode)
            {
                neighbourNodes[i].parent = currentNode;
                pathFound = true;
                CreateFinalPath(goalNode, ref finalPath);
                for (int k = 0; k < finalPath.Count; k++)
                {
                    finalPath[k].Cube.GetComponent<MeshRenderer>().material.color = Color.white;
                }
                algoVersion++;
            }
            if (!closedList.Contains(neighbourNodes[i]))
            {
                int newCost = CalculateDistance(neighbourNodes[i].gridPosition, currentNode.gridPosition) + currentNode.GCost;
                if (!openList.Contains(neighbourNodes[i]) || newCost < neighbourNodes[i].GCost)
                {
                    neighbourNodes[i].GCost = newCost;
                    neighbourNodes[i].HCost = CalculateDistance(neighbourNodes[i].gridPosition, goalNode.gridPosition);
                    neighbourNodes[i].parent = currentNode;
                    if (!closedList.Contains(neighbourNodes[i]))
                    {
                        openList.Add(neighbourNodes[i]);
                    }
                }
            }
        }
    }

    public int CalculateDistance(Vector3Int startPosition, Vector3Int destinationPosition)
    {
        if (startPosition == destinationPosition) return 0;

        Vector3Int distanceValue = new Vector3Int
            (Mathf.Abs(startPosition.x - destinationPosition.x),
            Mathf.Abs(startPosition.y - destinationPosition.y),
            Mathf.Abs(startPosition.z - destinationPosition.z));

        return distanceValue.x + distanceValue.y + distanceValue.z;
    }
    void FindFCost(Vector3Int startNode, Vector3Int goalNodePosition)
    {
        for (int i = 0; i < neighbourNodes.Count; i++)
        {
            neighbourNodes[i].GCost = CalculateDistance(startNode, neighbourNodes[i].gridPosition);
            neighbourNodes[i].HCost = CalculateDistance(neighbourNodes[i].gridPosition, goalNodePosition);
        }
    }

    void SetNewNeighbors(Vector3Int startPosition, Vector3Int goalPosition)
    {
        openList.Clear();
        closedList.Clear();

        startNode = grid.GetNodeBasedOnPosition(startPosition);
        startNode.Cube.GetComponent<MeshRenderer>().material.color = Color.cyan;

        goalNode = grid.GetNodeBasedOnPosition(goalPosition);
        goalNode.cubeObject.GetComponent<MeshRenderer>().material.color = Color.cyan;

        pathFound = false;

        startNode.GCost = 0;
        startNode.HCost = 0;
        startNode.parent = null;

        goalNode.GCost = 0;
        goalNode.HCost = 0;
        goalNode.parent = null;
    }

    void CreateFinalPath(Node node, ref List<Node> finalPath)
    {
        finalPath.Add(node);
        if (node.parent != null)
        {
            CreateFinalPath(node.parent, ref finalPath);
        }
    }
}



