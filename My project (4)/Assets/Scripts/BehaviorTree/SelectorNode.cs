using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class SelectorNode : ParentNode
{
    public override NodeStatus Execute()
    {
        LogNode();
        for (int i = 0; i < children.Count; i++)
        {
            NodeStatus childNodeStatus = children[i].Execute();
            if(childNodeStatus == NodeStatus.Success)
            {
                Debug.Log("SelectorNode successful");
                return childNodeStatus;
            }
            else if(childNodeStatus == NodeStatus.Failure)
            {
                Debug.Log("SelectorNode child failed");
                continue;    
            }
        }
        Debug.Log("SelectorNode failed");
        return NodeStatus.Failure;
    }
}
