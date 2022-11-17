using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GabrielonAttackBehaviour : StateMachineBehaviour
{

    [SerializeField] float minDistance;
    private Gabrielon gabrielon;
    private Transform transform;
    private Vector3 pointAttack;
    private float speedMovement;


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SoundController.instance.PlayEvilLaughterSound();
        gabrielon = animator.gameObject.GetComponent<Gabrielon>();
        pointAttack = gabrielon.GetPointAttack();
        speedMovement = gabrielon.GetSpeedMovement() * 4;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, pointAttack, speedMovement * Time.deltaTime);

        if (Vector2.Distance(animator.transform.position, pointAttack) < minDistance)
        {
            animator.SetTrigger("Back");
        }
    }
}
