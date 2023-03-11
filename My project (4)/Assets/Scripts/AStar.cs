using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;

public class AStar : MonoBehaviour
{
    Grid grid;

    [Header("Start Node Positions")]
    [SerializeField] Vector3Int startNodePosition;
    [SerializeField] Vector3Int startNodePosition_1;
    [SerializeField] Vector3Int startNodePosition_2;
    [SerializeField] Vector3Int startNodePosition_3;

    [Header("Goal Node Positions")]
    [SerializeField] Vector3Int goalNodePosition;
    [SerializeField] Vector3Int goalNodePosition_1;
    [SerializeField] Vector3Int goalNodePosition_2;
    [SerializeField] Vector3Int goalNodePosition_3;

    List<Node> neighbourNodes = new List<Node>();
    List<Node> openList = new List<Node>();
    List<Node> closedList = new List<Node>();
    List<Node> finalNode = new List<Node>();

    Node startNode;
    Node goalNode;
    Node currentNode;

    bool pathFound;

    int algoVersion;
    private void Start()
    {
        grid = GetComponent<Grid>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            grid.ClearGrid();
            FindFCost(startNodePosition);
            SetNewNeighbors(startNodePosition, goalNodePosition);
            openList.Add(startNode);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            grid.ClearGrid();
            FindFCost(startNodePosition_1);
            SetNewNeighbors(startNodePosition_1, goalNodePosition_1);
            openList.Add(startNode);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            grid.ClearGrid();
            FindFCost(startNodePosition_2);
            SetNewNeighbors(startNodePosition_2, goalNodePosition_2);
            openList.Add(startNode);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            grid.ClearGrid();
            FindFCost(startNodePosition_3);
            SetNewNeighbors(startNodePosition_3, goalNodePosition_3);
            openList.Add(startNode);
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && !pathFound)
        {
            CreateNeighbors();
        }
    }

    void CreateNeighbors()
    {
        openList.Sort();
        currentNode = openList[0];
        openList.RemoveAt(0);

        currentNode.Cube.GetComponent<MeshRenderer>().material.color = Color.magenta;

        closedList.Add(currentNode);
        neighbourNodes.Clear();

        Vector3Int rightNodePosition = new Vector3Int(1, 0, 0);
        if (currentNode.gridPosition.x + 1 < grid.gridSize.x)
        {
            Node rightNode = grid.GetNodeBasedOnPosition(currentNode.gridPosition + rightNodePosition);
            neighbourNodes.Add(rightNode);
        }

        Vector3Int leftNodePosition = new Vector3Int(-1, 0, 0);
        if (currentNode.gridPosition.x - 1 > grid.gridSize.x)
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
        if (currentNode.gridPosition.z - 1 > grid.gridSize.z)
        {
            Node bottomNode = grid.GetNodeBasedOnPosition(currentNode.gridPosition + bottomNodePosition);
            neighbourNodes.Add(bottomNode);
        }

        CalculateNeighborNodes();
    }

    void CalculateNeighborNodes()
    {
        for (int i = 0; i < neighbourNodes.Count; i++)
        {
            neighbourNodes[i].cubeObject.GetComponent<MeshRenderer>().material.color = Color.green;

            if (neighbourNodes[i] == goalNode)
            {
                pathFound = true;
                neighbourNodes[i].parent = currentNode;

                FindPath(neighbourNodes[i]);
                for (int k = 0; k < finalNode.Count; k++)
                {
                    finalNode[k].Cube.GetComponent<MeshRenderer>().material.color = Color.white;
                }
                algoVersion++;
            }
            if (!openList.Contains(neighbourNodes[i]) && !closedList.Contains(neighbourNodes[i]))
            {
                openList.Add(neighbourNodes[i]);
            }

            int newCost = CalculateDistance(neighbourNodes[i].gridPosition, currentNode.gridPosition) + currentNode.GCost;

            if (newCost < neighbourNodes[i].GCost || neighbourNodes[i].GCost <= 0 || neighbourNodes[i].version < algoVersion)
            {
                neighbourNodes[i].GCost = newCost;
                neighbourNodes[i].HCost = CalculateDistance(neighbourNodes[i].gridPosition, goalNode.gridPosition);
                neighbourNodes[i].parent = currentNode;
                if (neighbourNodes[i].version < algoVersion)
                {
                    neighbourNodes[i].parent = null;
                    neighbourNodes[i].version = algoVersion;
                }
            }
            if (!closedList.Contains(neighbourNodes[i]))
            {
                neighbourNodes[i].parent = currentNode;
            }
        }
    }

    public int CalculateDistance(Vector3Int startPosition, Vector3Int destinationPosition)
    {
        Vector3Int distanceValue = new Vector3Int
            (Mathf.Abs(startPosition.x - destinationPosition.x),
            Mathf.Abs(startPosition.y - destinationPosition.y),
            Mathf.Abs(startPosition.z - destinationPosition.z));

        return distanceValue.x + distanceValue.y + distanceValue.z;
    }
    void FindFCost(Vector3Int startNode)
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
        finalNode.Clear();

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

    void FindPath(Node node)
    {
        finalNode.Add(node);
        if (node.parent != null)
        {
            finalNode.Add(node.parent);
            FindPath(node.parent);
        }
    }

}



