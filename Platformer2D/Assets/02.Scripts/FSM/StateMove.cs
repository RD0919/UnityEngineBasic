using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMove : State
{
    public override bool canExecute => true;
    private GroundDetetor _groundDetetor;

    public StateMove(StateMachine machine) : base(machine)//생성자 machine을 먼저 실행한 뒤 아래의 내용을 실행
    {
        _groundDetetor = machine.GetComponent<GroundDetetor>();
    }

    public override StateType MoveNext()
    {
        StateType destination = StateType.Move;

        switch (currentStep)
        {
            case IState<StateType>.Step.None:
                {
                    currentStep++;
                }
                break;
            case IState<StateType>.Step.Start:
                {
                    animator.Play("Move");
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
                    if (_groundDetetor.isDetected == false)
                        destination = StateType.Fall;
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
