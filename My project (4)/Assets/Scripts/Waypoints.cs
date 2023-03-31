using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class Waypoints : MonoBehaviour
{
    //run astar whenever we change the goalnode

    AStar aStar;
    List<Node> finalPath;
    bool followPath;
    int index;
    [Header("Speed")]
    [SerializeField] int speed;

    [Header("Position")]
    [SerializeField] Vector3Int startPosition;
    [SerializeField] Vector3Int goalPosition;
    void Start()
    {
        aStar = FindObjectOfType<AStar>();
        followPath = aStar.InitializeAstar(startPosition, goalPosition, out finalPath);
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
        RunAStarWhenPositionChanges();
    }

    void SetStartPositionForObject()
    {
        if (followPath)
        {
            transform.position = finalPath[index].worldPosition;
        }
    }
    void RunAStarWhenPositionChanges()
    {
        if (goalPosition != finalPath[finalPath.Count - 1].gridPosition || startPosition != finalPath[0].gridPosition)
        {
            followPath = aStar.InitializeAstar(startPosition, goalPosition, out finalPath);
            index = 0;
            SetStartPositionForObject();
        }
    }
}