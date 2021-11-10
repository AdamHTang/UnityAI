/* Author: Adam Tang
 * Date Created: 11-10-2021
 * Date Modified: 11-10-2021
 * Description: Behaviors for chase state.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMesh), typeof(SightLine), typeof(Animator))]

public class AttackState : MonoBehaviour, IFSMState
{
    // Variables //
    public float escapeDistance = 10.0f;
    public float maxAttackDistance = 2.0f;
    public float delayBetweenAttacks = 2.0f;
    public string animationAttackParamName = "Attack";
    public string TargetTag = "Player";
    public FSMStateType stateName { get { return FSMStateType.Attack; } }

    private NavMeshAgent thisAgent;
    private Animator thisAnimator;
    private Transform Target;
    private bool isAttacking;

    private void Awake()
    {
        thisAgent = GetComponent<NavMeshAgent>();
        thisAnimator = GetComponent<Animator>();
        Target = GameObject.FindGameObjectWithTag(TargetTag).transform;
    }

    public void onEnter()
    {
        StartCoroutine(DoAttack());
    }

    private IEnumerator DoAttack()
    {
        while (true)
        {
            if (isAttacking)
            {
                Debug.Log("Attack Player");
                thisAnimator.SetTrigger(animationAttackParamName);
                thisAgent.isStopped = true;
                yield return new
                WaitForSeconds(delayBetweenAttacks);
            }
            yield return null;
        }
    }


        public void doAction()
        {
            isAttacking = Vector3.Distance(Target.position, transform.position) < maxAttackDistance;

            if (!isAttacking)
            {
                thisAgent.isStopped = false;
                thisAgent.SetDestination(Target.position);
            }
        }
    
    public FSMStateType ShouldTransitionToState()
    {
        if (Vector3.Distance(Target.position, transform.position) > escapeDistance)
        {
            return FSMStateType.Chase;
        }
        return FSMStateType.Attack;
    }

    public void onExit()
    {
        thisAgent.isStopped = true;
        isAttacking = false;
        StopCoroutine(DoAttack());
    }
}
