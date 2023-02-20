using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class GridSystem : MonoBehaviour
{
    [SerializeField] Vector3 gridSize;
    int total;
    NodeSystem[] nodes;

    private void Start()
    {
        CreateGrid();
    }

    void CreateGrid()
    {
        total = (int)gridSize.x * (int)gridSize.z;
        nodes = new NodeSystem[total];

        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.z; y++)
            {
                Vector3 localPosition = new Vector3(x, 0, y);
                Vector3 worldPosition = transform.position + localPosition;
                int totalNodesSpawn = x + y;
                nodes[totalNodesSpawn] = new NodeSystem(localPosition, worldPosition);
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = worldPosition;
                cube.transform.localPosition = localPosition; 
                cube.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);  
            }

        }
    }

}
