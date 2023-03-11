using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Node : IComparable
{
    public Vector3Int gridPosition;
    public Vector3Int worldPosition;

    public Node parent;

    public int gCost;
    public int hCost;
    public int fCost;
    public int version;

    bool isWalkable;

    public GameObject cubeObject;

    public TextMeshProUGUI gCostText;
    public TextMeshProUGUI hCostText;
    public TextMeshProUGUI fCostText;


    public Node(Vector3Int gridPosition, Vector3Int worldPosition)
    {
        this.gridPosition = gridPosition;
        this.worldPosition = worldPosition;
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
            gCostText = cubeObject.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            hCostText = cubeObject.transform.GetChild(0).transform.GetChild(1).GetComponent<TextMeshProUGUI>();
            fCostText = cubeObject.transform.GetChild(0).transform.GetChild(2).GetComponent<TextMeshProUGUI>();
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
            fCost = gCost + hCost;
            fCostText.text = fCost.ToString();
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
            fCost = gCost + hCost;
            fCostText.text = fCost.ToString();
        }
    }

    public int CompareTo(object obj)
    {
        Node otherNode = (Node)obj;

        if(fCost < otherNode.fCost)
        {
            return -1;
        }
        else if(fCost > otherNode.fCost)
        {
            return 1;
        }

        return 0;
    }
}
