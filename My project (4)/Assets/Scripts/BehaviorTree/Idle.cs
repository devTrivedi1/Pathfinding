using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : BehaviorNode
{
    public override NodeStatus Execute()
    {
        LogNode();
        return NodeStatus.Success;
    }
}
