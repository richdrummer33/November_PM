using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportLocomotion : MonoBehaviour
{
    public LineRenderer laserLine;

    public Transform xrRig;

    Vector3 teleportPosition;

    public string teleportButtonName;

    // Update is called once per frame
    void Update()
    {
        laserLine.SetPosition(0, transform.position); // Laser always starts on the hand

        if(Input.GetButton(teleportButtonName)) // button held down
        {
            RaycastHit raycastHitInfo; // This will hold the point that we are aiming at

            laserLine.enabled = true;

            if (Physics.Raycast(transform.position, transform.forward, out raycastHitInfo, Mathf.Infinity) == true) //raycastHitInfo will receive information about the object and position that was hit (a collider)
            {
                teleportPosition = raycastHitInfo.point; // Take note of where we are aiming, so that we can teleport there when the button is released

                laserLine.SetPosition(1, raycastHitInfo.point);
            }
            else
            {
                laserLine.SetPosition(1, transform.position + transform.forward * 100f); // Set end of line 100m in front of the controller
            }
        }
        if(Input.GetButtonUp(teleportButtonName)) // Released button, attempt teleport
        {
            // Calculate offset then apply to the rig's position
            Vector3 offset = xrRig.position - Camera.main.transform.position;

            offset.y = 0f; // No movement in the vertical direction 

            xrRig.position = teleportPosition + offset; // Need to move the XR rig to the teleportPosition
            
            laserLine.enabled = false;
        }
    }
}
