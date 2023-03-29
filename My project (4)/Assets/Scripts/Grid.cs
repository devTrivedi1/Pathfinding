using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public Vector3Int gridSize;
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
                Vector3Int localPosition = new Vector3Int(x, 0, z);
                Vector3Int worldPosition = new Vector3Int(localPosition.x * gridSize.x, 0, localPosition.z * gridSize.z);
                int totalNodesSpawn = x + z * gridSize.x;
                nodes[totalNodesSpawn] = new Node(localPosition, worldPosition);
                nodes[totalNodesSpawn].Cube = Instantiate(nodePrefab, worldPosition, Quaternion.identity);
                nodes[totalNodesSpawn].Cube.transform.position = worldPosition;
                nodes[totalNodesSpawn].Cube.transform.localScale = new Vector3(gridSize.x, 1, gridSize.z);
            }
        }
    }
    public void ClearGrid()
    {
        for (int i = 0; i < nodes.Length; i++)
        {
            nodes[i].Cube.GetComponent<MeshRenderer>().material.color = Color.black;
        }
    }

    public Node GetNodeBasedOnPosition(Vector3 nodePosition)
    {
        int index = (int)(nodePosition.x + nodePosition.z * gridSize.x);
        return nodes[index];
    }
}
