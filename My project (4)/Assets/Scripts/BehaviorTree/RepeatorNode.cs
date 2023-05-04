using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatorNode : ParentNode
{
    public override NodeStatus Execute()
    {
        LogNode();
        for (int i = 0; i < children.Count;)
        {
            NodeStatus childNodeStatus = children[i].Execute();
            if (childNodeStatus == NodeStatus.Failure)
            {
                Debug.Log("Repeator children failure");
                childNodeStatus = children[i].Execute();
                i = 0;
                continue;
            }
            else if (childNodeStatus == NodeStatus.Success)
            {
                Debug.Log("Repeator children success");
                i++;
            }
        }
        Debug.Log("RepeatorStatus success");
        return NodeStatus.Success;  
    }
}
