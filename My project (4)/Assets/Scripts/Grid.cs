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
                nodes[totalNodesSpawn].Cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                nodes[totalNodesSpawn].Cube.GetComponent<MeshRenderer>().material.color = Color.white;
                nodes[totalNodesSpawn].Cube.transform.position = worldPosition;
                nodes[totalNodesSpawn].Cube.transform.localPosition = localPosition;
            }
        }
    }

    public Node GetStartingNode(Vector3Int nodePosition)
    {
        if (nodePosition.x < 0 || nodePosition.x >= gridSize.x ||
           nodePosition.z < 0 || nodePosition.z >= gridSize.z)
        {
            return null;
        }
        int index = nodePosition.x + nodePosition.z * gridSize.x;
        return nodes[index];
    }
    int CalculateDistance(Vector3Int currentPosition, Vector3Int distance)
    {
        /*Vector3Int distanceValue = new Vector3Int
            (Mathf.Abs(currentPosition.x - distance.x),
            Mathf.Abs(currentPosition.y - distance.y),
            Mathf.Abs(currentPosition.z - distance.z));*/

        Vector3Int distanceValue;
        distanceValue.x = Mathf.Abs(currentPosition.x - distanceValue.x);
        distanceValue.y = Mathf.Abs(currentPosition.y - distanceValue.y);
        distanceValue.z = Mathf.Abs(currentPosition.z - distanceValue.z);

        return distanceValue.x + distanceValue.y + distanceValue.z;
    }

}
