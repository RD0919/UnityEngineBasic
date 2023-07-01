using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateStandUp : State
{
    public override bool canExecute => true;
    private GroundDetetor _groundDetetor;

    public StateStandUp(StateMachine machine) : base(machine)
    {
        _groundDetetor = machine.GetComponent<GroundDetetor>();
    }

    public override StateType MoveNext()
    {
        StateType destination = StateType.StandUp;

        switch (currentStep)
        {
            case IState<StateType>.Step.None:
                {
                    currentStep++;
                }
                break;
            case IState<StateType>.Step.Start:
                {
                    animator.Play("StandUp");
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

                    if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
                    {
                        destination = movement.horizontal == 0.0f ? StateType.Idle : StateType.Move;
                    }
                    else if(_groundDetetor.isDetected == false)
                    {
                        destination = StateType.Fall;
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
