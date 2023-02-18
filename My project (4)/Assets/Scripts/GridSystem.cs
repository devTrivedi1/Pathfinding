using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class GridSystem : MonoBehaviour
{
    int width = 3;
    int height = 6;

    int total;

    NodeSystem[] nodes;

    private void Start()
    {
        total = width * height;
        nodes = new NodeSystem[total];

        for (int i = 0; i < nodes.Length; i++)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = new Vector3(0, 0.5f, 0);

        }
    }

}
