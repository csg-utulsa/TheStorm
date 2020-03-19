using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1_Idle : StateMachineBehaviour
{
    public float waitTime;

    private Boss1 boss;
    public float timeWaited;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss = animator.GetComponent<Boss1>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(timeWaited >= waitTime)
        {
            boss.StopWaiting();
        }
        else
        {
            timeWaited += Time.deltaTime;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timeWaited = 0;
    }
}
