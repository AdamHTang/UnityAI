using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM : MonoBehaviour
{
    public FSMStateType startState = FSMStateType.Patrol;
    private IFSMState[] statePool;
    private IFSMState currentState;

    public readonly IFSMState emptyAction = new EmptyState();
}
