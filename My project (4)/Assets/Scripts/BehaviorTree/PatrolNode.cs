using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolNode : BehaviorNode
{

    public override NodeStatus Execute()
    {
        LogNode();
        return NodeStatus.Success;
    }
}
