using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class Node
{
    public Vector3 gridPosition;
    public Vector3 worldPosition;

    public int gCost;
    public int hCost;

    bool isWalkable;

    public GameObject cubeObject;

    public Text gCostText;
    public Text hCostText;
    public Text fCostText;


    public Node(Vector3 gridPos, Vector3 worldPos)
    {
        this.gridPosition = gridPos;
        this.worldPosition = worldPos;
    }

    public GameObject Cube
    {
        get
        {
            return cubeObject;
        }
        set
        {
            cubeObject = value;
            gCostText = cubeObject.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>();
            hCostText = cubeObject.transform.GetChild(0).transform.GetChild(1).GetComponent<Text>();
            fCostText = cubeObject.transform.GetChild(0).transform.GetChild(2).GetComponent<Text>();
        }
    }
    public int GCost
    {
        get
        {
            return gCost;

        }
        set
        {
            gCost = value;
            gCostText.text = value.ToString();
        }
    }

    public int HCost
    {
        get
        {
            return hCost;
        }
        set
        {
            hCost = value;
            hCostText.text = value.ToString();
        }
    }
    public int fCost
    {
        get { return gCost + hCost; }

    }
}
