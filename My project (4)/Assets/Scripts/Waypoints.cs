using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class Waypoints : MonoBehaviour
{
    AStar aStar;
    List<Node> finalPath;
    [SerializeField] bool followPath;
    [SerializeField] int index;
    [SerializeField] int speed;
    [SerializeField] Vector3Int startNode;
    [SerializeField] Vector3Int goalNode;
    void Start()
    {
        aStar = FindObjectOfType<AStar>();
        followPath = aStar.InitializeAstar(startNode, goalNode, out finalPath);
        index = 0;
        SetStartPositionForObject();
    }

    void Update()
    {
        if (followPath)
        {
            if (Vector3.Distance(transform.position, finalPath[index].worldPosition) <= 0.1f)
            {
                index++;
                if (index >= finalPath.Count)
                {
                    followPath = false;
                    return;
                }
            }
            Vector3 direction = (finalPath[index].worldPosition - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    void SetStartPositionForObject()
    {
        if (followPath)
        {
            transform.position = finalPath[index].worldPosition;
        }
    }
}