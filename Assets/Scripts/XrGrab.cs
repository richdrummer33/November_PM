﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XrGrab : MonoBehaviour
{
    public GameObject collidingObject; // Object we're touching

    GameObject heldObject;

    public Animator handAnimator;

    public string gripAxisName;

    bool handIsClosed = false;

    FixedJoint thisGrabJoint;

    Vector3 lastPosition; // To calculate velocity with
    Vector3 velocity; 

    // To detect what I'm grabbing
    private void OnTriggerEnter(Collider other)
    {
        collidingObject = other.gameObject; // Take note of what object we're touching
    }

    private void OnTriggerExit(Collider other)
    {
        collidingObject = null; // Forget the obj we were toucing
    }

    // Start is called before the first frame update
    void Start()
    {
        lastPosition = transform.position; // Optional
    }

    // Update is called once per frame
    void Update()
    {
        #region Grab and Release
        // Checking mouse click to attempt grab on the object we're touching
        if (Input.GetAxis(gripAxisName) > 0.25f && handIsClosed == false) // IF *just* pressed the grip
        {
            if (handAnimator != null)
            {
                handAnimator.SetBool("Closed", true); // Will make animation controller close the hand
            }

            if (collidingObject != null)
            {
                Grab();
            }

            handIsClosed = true; // Taking note that we just closed the hand
        }
        else if (Input.GetAxis(gripAxisName) < 0.25f && handIsClosed == true) // Release the right mouse button
        {
            if (handAnimator != null)
            {
                handAnimator.SetBool("Closed", false); // Will make animation controller open the hand
            }

            if (heldObject != null)
            {
                Release();
            }

            handIsClosed = false;
        }
        #endregion

        velocity = (transform.position - lastPosition) / Time.deltaTime;

        lastPosition = transform.position;
    }

    void Grab()
    {
        //collidingObject.GetComponent<Rigidbody>().isKinematic = true; // Disable ability for external forces to move this object

        collidingObject.transform.SetParent(this.transform); // Makes collidingObj child of hand to follow it

        thisGrabJoint = gameObject.AddComponent<FixedJoint>(); // Actually creates the component on this game object

        thisGrabJoint.connectedBody = collidingObject.GetComponent<Rigidbody>();

        thisGrabJoint.breakForce = 500f; // Can change this value as you like

        thisGrabJoint.breakTorque = 500f;

        heldObject = collidingObject; // "Remember" what we;re holding, so we know what to release on Mouse Up
    }

    void Release()
    {
        //heldObject.GetComponent<Rigidbody>().isKinematic = false; // From original grab implementation

        heldObject.transform.SetParent(null);

        if (thisGrabJoint != null)
            Destroy(thisGrabJoint);

        heldObject.GetComponent<Rigidbody>().velocity = velocity; 

        heldObject = null; // "Forgetting" what we were holding    
    }

    private void OnJointBreak(float breakForce)
    {
        Release();
    }
}
