using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] Vector3Int gridSize;
    [SerializeField] GameObject nodePrefab;
    int total;
    public Node[] nodes;

    private void Awake()
    {
        CreateGrid();
    }

    void CreateGrid()
    {
        total = gridSize.x * gridSize.z;
        nodes = new Node[total];


        for (int z = 0; z < gridSize.z; z++)
        {
            for (int x = 0; x < gridSize.x; x++)
            {
                Vector3 localPosition = new Vector3(x, 0, z);
                Vector3 worldPosition = new Vector3(localPosition.x * gridSize.x, 0, localPosition.z * gridSize.z);
                int totalNodesSpawn = x + z * gridSize.x;
                nodes[totalNodesSpawn] = new Node(localPosition, worldPosition);
                nodes[totalNodesSpawn].Cube = Instantiate(nodePrefab, worldPosition, Quaternion.identity);
                nodes[totalNodesSpawn].Cube.transform.localPosition = localPosition;
            }
        }
    }

    public Node GetNodeBasedOnPosition(Vector3Int nodePosition)
    {
        if (nodePosition.x < 0 || nodePosition.x >= gridSize.x ||
           nodePosition.z < 0 || nodePosition.z >= gridSize.z)
        {
            return null;
        }
        int index = nodePosition.x + nodePosition.z * gridSize.x;
        return nodes[index];
    }
    public float CalculateDistance(Vector3 startPosition, Vector3 destinationPosition)
    {
        Vector3 distanceValue = new Vector3
            (Mathf.Abs(startPosition.x - destinationPosition.x),
            Mathf.Abs(startPosition.y - destinationPosition.y),
            Mathf.Abs(startPosition.z - destinationPosition.z));


        return distanceValue.x + distanceValue.y + distanceValue.z;
    }

}
