/* Author: Adam Tang
 * Date Created: 10-27-2021
 * Date Modified: 10-27-2021
 * Description: Move agent to the destination.
 * 
 */



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class FollowDesination : MonoBehaviour
{
    // Variables //
    public Transform destination = null;
    private NavMeshAgent ThisAgent = null;

    void Awake()
    {
        ThisAgent = GetComponent<NavMeshAgent>();
    } // End Awake()

    // Update is called once per frame
    void Update()
    {
        ThisAgent.SetDestination(destination.position);
    } // End Update()
}
