using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateIdle : State
{
    public override bool canExecute => true;
    private GroundDetetor _groundDetetor;

    public StateIdle(StateMachine machine) : base(machine)
    {
        _groundDetetor = machine.GetComponent<GroundDetetor>();
    }

    public override StateType MoveNext()
    {
        StateType destination = StateType.Idle;

        switch (currentStep)
        {
            case IState<StateType>.Step.None:
                {
                    currentStep++;
                }
                break;
            case IState<StateType>.Step.Start:
                {
                    animator.Play("Idle");
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
                    if(_groundDetetor.isDetected == false)
                        destination= StateType.Fall;
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
