using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceNode : ParentNode
{
    public override NodeStatus Execute()
    {
        LogNode();

        for (int i = 0; i < children.Count; i++)
        {
            NodeStatus childNodeStatus = children[i].Execute();
            if (childNodeStatus == NodeStatus.Success)
            {
                Debug.Log("SequenceNode children success");
                continue;
            }
            else if (childNodeStatus == NodeStatus.Failure)
            {
                Debug.Log("SequenceNode failed");
                return childNodeStatus;
            }
        }
        Debug.Log("SequenceNode success");
        return NodeStatus.Success;
    }
}
