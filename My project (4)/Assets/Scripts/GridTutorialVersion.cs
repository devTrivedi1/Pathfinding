using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class GridTutorialVersion : MonoBehaviour
{
    //Practice version from Sebastian's video tutorial on creating a node grid

    public LayerMask unwalkableMask;
    public Vector2 gridWorldSize;
    public float nodeRadius;
    NodeTutorialVersion[,] grid;

    float nodeDiameter;
    int gridSizeX;
    int gridSizeY;

    private void Start()
    {
        nodeDiameter = nodeRadius * 2;
        gridSizeX = Mathf.RoundToInt(gridWorldSize.x / nodeDiameter);
        gridSizeY = Mathf.RoundToInt(gridWorldSize.y / nodeDiameter);
        //How many nodes to fit onto the grid itself for x and Y
        //RoundToInt is to ensure that we don't want to have half a node or so
        //this rounds the value to the nearest int value

        CreateGrid();


    }

    private void CreateGrid()
    {
        grid = new NodeTutorialVersion[gridSizeX, gridSizeY];
        // center of the world, subtracting vec3 to get the left edge, and getting vec3.forward to get the bottom left corner 
        Vector3 worldBottomLeft = transform.position - Vector3.right * gridWorldSize.x / 2 - Vector3.forward * gridWorldSize.y / 2;
        //This is to get the world position, for the forloop to get the collision check

        for (int x = 0; x < gridSizeX; x++) //Collision check to see if they're walkable or not
        {
            for (int y = 0; y < gridSizeY; y++)
            {
                Vector3 worldPoint = worldBottomLeft
                    + Vector3.right * (x * nodeDiameter + nodeRadius)
                    + Vector3.forward * (y * nodeDiameter + nodeRadius);

                //As x increases, the increments of nodeDiameter also
                //increases around the world till it reaches the edge,
                //same thing applies for the y axis (z axis in 3d space)

                grid[x, y] = new NodeTutorialVersion(worldPoint);

                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
                cube.transform.position = new Vector3(worldPoint.x, 0, worldPoint.z);


            }
        }
    }

}
