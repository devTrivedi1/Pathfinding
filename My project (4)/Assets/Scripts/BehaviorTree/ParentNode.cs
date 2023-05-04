using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentNode : BehaviorNode
{
    protected List<BehaviorNode> children = new List<BehaviorNode>();

    public void AddChildren(BehaviorNode nodes)
    {
        children.Add(nodes);
    }
}
