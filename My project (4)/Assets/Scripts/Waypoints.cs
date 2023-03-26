using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class Waypoints : MonoBehaviour
{
    AStar aStar;
    List<Node> finalPath;
    bool followPath;
    int index;
    [SerializeField] int speed;
    void Start()
    {
        aStar = FindObjectOfType<AStar>();
        followPath = aStar.InitializeAstar(new Vector3Int(4,0,4), new Vector3Int(6,0,6), out finalPath);
        index = 0;
    }

    void Update()
    {
        if (followPath)
        {
            if(Vector3.Distance(transform.position, finalPath[index].worldPosition) <= 0.5f)
            {
                index++;
                if(index >= finalPath.Count)
                {
                    followPath = false;
                    return;
                }
            }
            Vector3 direction = (finalPath[index].worldPosition - transform.position).normalized;
            transform.position += finalPath[index].worldPosition * speed;
        }
    }
}
