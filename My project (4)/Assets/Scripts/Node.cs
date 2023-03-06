using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Node
{
    public Vector3 gridPosition;
    public Vector3 worldPosition;

    public int gCost;
    public int hCost;
    public int fCost;

    bool isWalkable;

    public GameObject cubeObject;

    public TextMeshProUGUI gCostText;
    public TextMeshProUGUI hCostText;
    public TextMeshProUGUI fCostText;


    public Node(Vector3 gridPosition, Vector3 worldPosition)
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
}
