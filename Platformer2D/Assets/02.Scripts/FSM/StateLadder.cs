using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateLadderUp : State
{
    public override bool canExecute => (machine.currentType == StateType.Idle || machine.currentType == StateType.Move || machine.currentType == StateType.Jump || machine.currentType == StateType.Fall) && _ladderDetecter.isGoupPossible;
    private LadderDetecter _ladderDetecter;
    private GroundDetector _groundDetector;
    private Ladder _ladder;
    public StateLadderUp(StateMachine machine) : base(machine)
    {
        _ladderDetecter = machine.GetComponent<LadderDetecter>();
        _groundDetector = machine.GetComponent<GroundDetector>();
    }

    public override StateType MoveNext()
    {
        StateType destination = StateType.Move;

        switch (currentStep)
        {
            case IState<StateType>.Step.None:
                {
                    _ladder = _ladderDetecter.upLadder;
                    movement.isMovable = false;
                    movement.isDirectionChangeable = false;
                    rigidbody.velocity = Vector2.zero;
                    rigidbody.bodyType = RigidbodyType2D.Kinematic;
                    animator.speed = 0.0f;
                    animator.Play("Ladder");

                    if(_groundDetector.isDetected)
                    {
                        transform.position = _ladder.upStartPos;
                    }
                    else
                    {
                        transform.position = new Vector2(_ladder.transform.position.x, transform.position.y);
                    }

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
                    if(_groundDetector.isDetected)
                    {
                        destination = movement.horizontal == 0.0f ? StateType.Idle : StateType.LadderUp;
                    }
                    else if(transform.position.y < _ladder.downEndPos.y)
                    {
                        destination = StateType.Idle;
                    }
                    else if(transform.position.y > _ladder.upEndPos.y)
                    {
                        transform.position = _ladder.topPos;
                        destination = movement.horizontal == 0.0f ? StateType.Idle : StateType.Move;
                    }
                    else
                    {
                        float vertical = Input.GetAxis("Vertical");
                        animator.speed = Mathf.Abs(vertical);
                        transform.position += Vector3.up * vertical * character.ladderSpeed * Time.deltaTime;
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
