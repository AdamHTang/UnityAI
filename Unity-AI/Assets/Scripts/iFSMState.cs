/* Author: Adam Tang
 * Date Created: 11-3-2021
 * Date Modified: 11-3-2021
 * Description: Interface for Chick States
 * 
 */

public interface IFSMState{
    FSMStateType stateName { get; }

    void onEnter();
    void onExit();
    void doAction();

    FSMStateType ShouldTransitionToState();
}