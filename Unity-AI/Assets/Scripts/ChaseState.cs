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

public class ChaseState : MonoBehaviour, IFSMState
{
    // Variables //
    public float movementSpeed = 2.5f;
    public float acceleration = 3.0f;
    public float angularSpeed = 720.0f;
    public string animationRunParamName = "Run";
    public float fov = 60.0f;
    public FSMStateType stateName { get { return FSMStateType.Chase; } }

    private NavMeshAgent thisAgent;
    private SightLine thisSightLine;
    private Animator thisAnimator;

    private readonly float minChaseDist = 2.0f;
    private float initialFOV = 0.0f;


    private void Awake()
    {
        thisAgent = GetComponent<NavMeshAgent>();
        thisSightLine = GetComponent<SightLine>();
        thisAnimator = GetComponent<Animator>();
    }

    public void onEnter()
    {
        initialFOV = thisSightLine.fieldOFView;
        thisSightLine.fieldOFView = fov;

        thisAgent.isStopped = false;
        thisAgent.speed = movementSpeed;
        thisAgent.acceleration = acceleration;
        thisAgent.angularSpeed = angularSpeed;

        thisAnimator.SetBool(animationRunParamName, true);
    }

    public void onExit()
    {
        thisAgent.isStopped = true;
        thisSightLine.fieldOFView = initialFOV;
        

    }

    public void doAction()
    {
        thisAgent.SetDestination(thisSightLine.LastKnownSighting);
    }

    public FSMStateType ShouldTransitionToState()
    {
        if (thisAgent.remainingDistance <= minChaseDist)
        {
            return FSMStateType.Attack;
        } else if (!thisSightLine.isTargetInSightLine)
        {
            return FSMStateType.Patrol;
        }
        return stateName;
    }

}
