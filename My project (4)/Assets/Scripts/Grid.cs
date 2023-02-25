using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] Vector3Int gridSize;
     public GameObject gameObjectCube;
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
                int totalNodesSpawn = z + x * gridSize.x;
                nodes[totalNodesSpawn] = new Node(localPosition, worldPosition);
                nodes[totalNodesSpawn].cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                nodes[totalNodesSpawn].cube.GetComponent<MeshRenderer>().material.color = Color.white;
                nodes[totalNodesSpawn].cube.transform.position = worldPosition;
                nodes[totalNodesSpawn].cube.transform.localPosition = localPosition;
            }

        }
    }

    public Node GetStartingNode(Vector3Int nodePosition)
    {
        int index = nodePosition.z + nodePosition.x * gridSize.x;
        return nodes[index];
    }
}
