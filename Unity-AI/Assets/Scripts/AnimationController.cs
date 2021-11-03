/* Author: Adam Tang
 * Date Created: 11-1-2021
 * Date Modified: 11-1-2021
 * Description: Play run/walk animation.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent), typeof(Animator))]

public class AnimationController : MonoBehaviour
{
    // Variables //
    public float runVelocity = 0.1f;
    public string AnimationRunParamName = "Run";
    public string AnimationSpeedParamName = "Speed";
    public float maxSpeed;
    private NavMeshAgent thisAgent = null;
    private Animator thisAnimator = null;

    void Awake()
    {
        thisAgent = GetComponent<NavMeshAgent>();
        thisAnimator = GetComponent<Animator>();
        maxSpeed = thisAgent.speed;
    } // end Awake()


    void Update()
    {
        thisAnimator.SetFloat(AnimationSpeedParamName, thisAgent.velocity.magnitude / maxSpeed);
    }
}
