using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Grid : MonoBehaviour
{
    [SerializeField] Vector3 gridSize;
     public GameObject gameObjectCube;
    int total;
    public Node[] nodes;

    private void Awake()
    {
        CreateGrid();
    }

    void CreateGrid()
    {
        total = (int)gridSize.x * (int)gridSize.z;
        nodes = new Node[total];

        for (int z = 0; z < gridSize.z; z++)
        {
            for (int x = 0; x < gridSize.x; x++)
            {
                Vector3 localPosition = new Vector3(x, 0, z);
                Vector3 worldPosition = localPosition * gridSize.x;
                int totalNodesSpawn = z + x;
                nodes[totalNodesSpawn] = new Node(localPosition, worldPosition);
                nodes[totalNodesSpawn].cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                nodes[totalNodesSpawn].cube.GetComponent<MeshRenderer>().material.color = Color.white;
                nodes[totalNodesSpawn].cube.transform.position = worldPosition;
                nodes[totalNodesSpawn].cube.transform.localPosition = localPosition;

                //GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                //cube.transform.position = worldPosition;
                //cube.transform.localPosition = localPosition;
                //cube.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
            }

        }
    }

    public Node GetStartingNode(Vector3Int nodePosition)
    {
        int index = nodePosition.x + nodePosition.z * total;
        return nodes[index];
    }
}
