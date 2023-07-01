using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateFall : State
{
    public override bool canExecute => true;
    private GroundDetetor _groundDetector;
    private float _statePosY;

    public StateFall(StateMachine machine) : base(machine)
    {
        _groundDetector = machine.GetComponent<GroundDetetor>();
    }

    public override StateType MoveNext()
    {
        StateType destination = StateType.Fall;

        switch (currentStep)
        {
            case IState<StateType>.Step.None:
                {
                    currentStep++;
                }
                break;
            case IState<StateType>.Step.Start:
                {
                    animator.Play("Fall");
                    _statePosY= rigidbody.position.y;
                    currentStep++;
                }
                break;
            case IState<StateType>.Step.Casting:
                {
                    currentStep++;
                }
                break;
            case IState<StateType>.Step.OnAction:
                {
                    if(_groundDetector.isDetected)
                    {
                        if(_statePosY - rigidbody.position.y > character.landDistance)
                            destination= StateType.Land;
                        else
                            destination = movement.horizontal == 0.0f ? StateType.Idle : StateType.Move;
                           
                    }
                }
                break;
            case IState<StateType>.Step.Finish:
                break;
            default:
                break;
        }

        return destination;

    }
}
