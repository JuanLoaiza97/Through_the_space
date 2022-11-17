using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GabrielonMotionBehaviour : StateMachineBehaviour
{
    private Gabrielon gabrielon;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        gabrielon = animator.gameObject.GetComponent<Gabrielon>();
    }

    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        gabrielon.Move();
    }
}
