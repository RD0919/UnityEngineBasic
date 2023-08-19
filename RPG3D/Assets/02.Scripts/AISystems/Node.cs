using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Status
{
    Success,
    Failure,
    Running,
}

public abstract class Node
{
    public BehaviourTree tree;
    public BlackBoard blackboard;
    public Node(BehaviourTree tree)
    {
        this.tree = tree;
        this.blackboard = tree.blackBoard;
    }

    public abstract Status Invoke();
}
