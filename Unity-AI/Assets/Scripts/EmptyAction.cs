/* Author: Adam Tang
 * Date Created: 11-3-2021
 * Date Modified: 11-3-2021
 * Description: Empty State
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyAction : IFSMState
{
    public FSMStateType stateName { get { return FSMStateType.None; } }
    

    public void onEnter()
    {

    }

    public  void onExit()
    {

    }

    public void doAction()
    {
        
    }

    public FSMStateType ShouldTransitionToState()
    {
        return FSMStateType.None;
    }

    
}
