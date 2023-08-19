using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class RandomSleep : Node
{
    private float _min;
    private float _max;

    public RandomSleep(BehaviourTree tree, float min, float max)
        : base(tree)
    {
        _min = min;
        _max = float.MaxValue;
    }

    public override Status Invoke()
    {
        tree.isSleeping= true;
        blackboard.BehaviourManager.StartCoroutine(C_WakeUp(Random.Range(_min, _max)));
        return Status.Running;
    }
    IEnumerator C_WakeUp(float after)
    {
        yield return new WaitForSeconds(after);
        tree.isSleeping = false;
    }
}