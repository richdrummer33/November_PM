using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicButtonController : MonoBehaviour
{
    public Transform button; // The thing that moves

    public Transform buttonClosedPosition;

    Vector3 originalPosition; // (x,y,z) - reserved in memory - default is (0,0,0)

    private void OnTriggerEnter(Collider other)
    {
        button.position = buttonClosedPosition.position; // Move button down

        GetComponent<AudioSource>().Play(); // Perform some action on press
    }

    private void OnTriggerExit(Collider other) // Hand (or some object/collider with rigidbody) left 
    {
        button.position = originalPosition; // Move it back
    }

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = button.position; // Record the orig pos @ game start
    }
}
