/* Author: Adam Tang
 * Date Created: 11-3-2021
 * Date Modified: 11-3-2021
 * Description: Defines the line of sight of object on other objects.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]

public class SightLine : MonoBehaviour
{
    // Variables //
    public Transform EyePoint; // point of eye.
    public string targetTag = "Player"; // the target we are looking for.
    public float fieldOFView = 45f; // angular margin of either side of the eye.
    public bool isTargetInSightLine { get; set; } = false;
    public Vector3 LastKnownSighting { get; set; } = Vector3.zero;

    private SphereCollider thisCollider = null;


    void Awake()
    {
        thisCollider = GetComponent<SphereCollider>();
        LastKnownSighting = transform.position;
    } // end Awake()

    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            UpdateSight(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            isTargetInSightLine = false;
        }
    }


    public bool hasClearLineofSightToTarget(Transform target)
    {
        RaycastHit info;
        Vector3 dirToTarget = (target.position - EyePoint.position).normalized;
        if (Physics.Raycast(EyePoint.position, dirToTarget, out info, thisCollider.radius))
        {
            if (info.transform.CompareTag(targetTag))
            {
                return true;
            }
        }
        return false;
    }

    private bool targetInFOV(Transform target)
    {
        Vector3 DirToTarget = target.position - EyePoint.position;
        float angle = Vector3.Angle(EyePoint.forward, DirToTarget);
        if (angle <= fieldOFView)
        {
            return true;
        }
        return false;
    } // end targetInFOV

  

    private void UpdateSight(Transform target)
    {
        isTargetInSightLine = hasClearLineofSightToTarget(target) && targetInFOV(target);
        if (isTargetInSightLine)
        {
            LastKnownSighting = target.position;
        }
    }
}
