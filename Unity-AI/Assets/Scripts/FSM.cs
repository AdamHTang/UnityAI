/* Author: Adam Tang
 * Date Created: 11-8-2021
 * Date Modified: 11-8-2021
 * Description: Finite State Machine script for transitions.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM : MonoBehaviour
{
    public FSMStateType startState = FSMStateType.Patrol;
    private IFSMState[] statePool;
    private IFSMState currentState;

    public readonly IFSMState emptyAction = new EmptyAction();

    private void Awake()
    {
        statePool= GetComponents<IFSMState>();
    }

    private void Start()
    {
        currentState = emptyAction;
        TransitionToState(startState);
    }

    private void Update()
    {
        currentState.doAction();    // Do what the current state says.
        FSMStateType transitionState = currentState.ShouldTransitionToState();  // Set the transition state when needed.
        if(transitionState != currentState.stateName)                                     // If the transition state and current state aren't the same, you need to make a transition.
        {
            TransitionToState(transitionState);
        }
    }

    private void TransitionToState(FSMStateType stateName)
    {
        currentState.onExit();
        currentState = getState(stateName);
        currentState.onEnter();
        Debug.Log("Transitioned to" + currentState.stateName);
    }

    private IFSMState getState(FSMStateType stateName)
    {
        foreach(var state in statePool)
        {
            if (state.stateName == stateName)
            {
                return state;
            }
        }
        return emptyAction;
    }

 
}
