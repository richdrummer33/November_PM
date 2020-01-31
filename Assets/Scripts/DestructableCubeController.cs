using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableCubeController : MonoBehaviour
{
    public BasicButtonController resetButton; // When this button is pressed, this cube returns to it's original position

    Vector3 startPosition; // Take note of position @ game start

    AudioSource source;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;

        resetButton.OnButtonPressed += ResetThisCube; // Some method (reset method)

        source = GetComponent<AudioSource>();

        rb = GetComponent<Rigidbody>();
    }

    void ResetThisCube()
    {
        // Reset to original position 
        transform.position = startPosition;
        GetComponent<Rigidbody>().velocity = Vector3.zero; // Making speed/velocity 0
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero; // Stop its movement (inertia)
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Impact velocity = " + collision.relativeVelocity.magnitude);

        if (collision.relativeVelocity.magnitude > 1f) // Ensure velocity is greater than some amount before playing sound
        {
            source.pitch = 1f + collision.relativeVelocity.magnitude / 4f; // Division by 4f is a scaling factor

            source.volume = collision.relativeVelocity.magnitude / 4f;

            source.Play();
        }
    }
}
