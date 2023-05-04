using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BehaviorNode
{
    public enum NodeStatus
    {
        Default,
        Success, 
        Running,
        Failure
    }
    
    protected void LogNode()
    {
        Debug.Log($"Starting behavior tree node" + this);
    }
    public virtual NodeStatus Execute()
    {
        return NodeStatus.Default;
    }
    
}
