using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseNode : BehaviorNode
{
    int random;
    public override NodeStatus Execute()
    {
        LogNode();

        random = Random.Range(0, 2);

        Debug.Log("The number is " + random);
        if (random != 1)
        {
            return NodeStatus.Failure;
        }
        else if (random == 1)
        {
            return NodeStatus.Success;
        }
        return NodeStatus.Default;
    }
}
