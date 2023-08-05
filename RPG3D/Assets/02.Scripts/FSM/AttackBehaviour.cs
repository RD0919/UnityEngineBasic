using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class AttackBehaviour : BehaviourBase
{
    public override void OnStateMachineExit(Animator animator, int stateMachinePathHash)
    {
        base.OnStateMachineExit(animator, stateMachinePathHash);
        manager.hasAttacked = false;
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);
        if(manager.currentMahineBehaviour == this)
        {
            if(stateInfo.normalizedTime >= 1.0f)
            {
                manager.ChangeState(StateID.Move);
            }
            //else if(stateInfo.normalizedTime >= 0.7f)
            //{
                //manager.hasAttacked = true;
            //}

        }
        
    }
}
