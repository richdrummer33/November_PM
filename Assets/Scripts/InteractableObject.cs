using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public virtual void Interact()
    {
        Debug.Log("The interact method was called");
    }

    public virtual void StopInteract()
    {
        Debug.Log("The StopInteract method was called");
    }

    public virtual void Grab()
    {
        Debug.Log("Grab method was called");
    }

    public virtual void Release()
    {
        Debug.Log("Release method was called");
    }
}
