/* Author: Adam Tang
 * Date Created: 11-8-2021
 * Date Modified: 11-8-2021
 * Description: Behaviors for patrol state.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMesh), typeof(SightLine), typeof(Animator))]

public class PatrolState : MonoBehaviour, IFSMState
{
    // Variables //
    public Transform destination;
    public float movementSpeed = 1.5f;
    public float acceleration = 2.0f;
    public float angularSpeed = 360.0f;
    public string animationRunParamName = "Run";
    public FSMStateType stateName { get { return FSMStateType.Patrol; } }

    private NavMeshAgent thisAgent;
    private SightLine thisSightLine;
    private Animator thisAnimator;


    private void Awake()
    {
        thisAgent = GetComponent<NavMeshAgent>();
        thisSightLine = GetComponent<SightLine>();
        thisAnimator = GetComponent<Animator>();
    }

    public void onEnter()
    {
        thisAgent.isStopped = false;
        thisAgent.speed = movementSpeed;
        thisAgent.acceleration = acceleration;
        thisAgent.angularSpeed = angularSpeed;

        thisAnimator.SetBool(animationRunParamName, false);
    }

    public void onExit()
    {
        thisAgent.isStopped = true;
        
    }

    public void doAction()
    {
        thisAgent.SetDestination(destination.position);
    }

    public FSMStateType ShouldTransitionToState(){
        if (thisSightLine.isTargetInSightLine)
        {
            return FSMStateType.Chase;
        }
        return stateName;
    }

}
