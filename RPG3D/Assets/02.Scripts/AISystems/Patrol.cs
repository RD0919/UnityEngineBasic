using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class patrol : Node
{
    private float _radius;

    public patrol(BehaviourTree tree, float radius)
        : base(tree)
    {
        _radius = radius;
    }

    public override Status Invoke()
    {
        float L = Random.Range(0, _radius);
        float theta = Random.Range(0.0f, 2* MathF.PI);// PI(rad) == 180(deg)
        float x = L * Mathf.Sin(theta);
        float z = L * MathF.Cos(theta);
        Vector3 expected =blackboard.transform.position + new Vector3(x, 0.0f, z);

        if(NavMesh.SamplePosition(expected, out NavMeshHit hit, 1.0f, NavMesh.AllAreas))
        {
            blackboard.agent.destination = hit.position;
            return Status.Success;
        }
        return Status.Failure;
    }
}