using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopToLook : BehaviorNode
{
    public override NodeStatus Execute()
    {
        LogNode();
        return NodeStatus.Success;

    }
}
