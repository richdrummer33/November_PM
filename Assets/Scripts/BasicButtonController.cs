using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicButtonController : MonoBehaviour
{
    public Transform button; // The thing that moves

    public Transform buttonClosedPosition;

    Vector3 originalPosition; // (x,y,z) - reserved in memory - default is (0,0,0)

    public delegate void ButtonPressEvent(); // Delegate 
    public ButtonPressEvent OnButtonPressed; // An instance of ButtonPressEvent() - can subscribe methods to this delegate

    private void OnTriggerEnter(Collider other)
    {
        button.position = buttonClosedPosition.position; // Move button down

        GetComponent<AudioSource>().Play(); // Perform some action on press

        OnButtonPressed(); // Run any methods that are subscribed to this delegate
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
