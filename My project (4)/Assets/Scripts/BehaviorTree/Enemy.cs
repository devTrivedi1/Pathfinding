using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    RepeatorNode repeatorNode;
    SequenceNode sequenceNode;
    SelectorNode selectorNode;
    PatrolNode patrolNode;
    Idle idle;
    ChaseNode chaseNode;
    StopToLook stopToLook;
   public bool treeExecuted;
    private void Start()
    {
        repeatorNode = new RepeatorNode();
        sequenceNode = new SequenceNode();
        patrolNode = new PatrolNode();
        idle = new Idle();
        selectorNode = new SelectorNode();
        stopToLook = new StopToLook();
        chaseNode = new ChaseNode(); 

        repeatorNode.AddChildren(sequenceNode);
        repeatorNode.AddChildren(selectorNode);
        
        sequenceNode.AddChildren(idle);
        sequenceNode.AddChildren(patrolNode);
        sequenceNode.AddChildren(stopToLook);

        selectorNode.AddChildren(chaseNode);
        
    }

    private void Update()
    {
        if(!treeExecuted)
        {
            repeatorNode.Execute();
            treeExecuted = true;
        }
    }
}
