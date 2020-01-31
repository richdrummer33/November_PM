using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public JointLeverController forwardBackControl, leftRightControl, rotateControl;

    public float speed = 5f;

    public float maxRotateSpeed = 20f; // Degrees per second

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(forwardBackControl.NormalizedControlValue()) > 0.05f) // 0.05 is 5% of the full-swing of the lever
        {
            transform.position = transform.position + transform.forward * Time.deltaTime * speed * forwardBackControl.NormalizedControlValue(); // Move fwd/back
        }

        if (Mathf.Abs(leftRightControl.NormalizedControlValue()) > 0.05f) // 0.05 is 5% of the full-swing of the lever
        {
            transform.position = transform.position + transform.right * Time.deltaTime * speed * leftRightControl.NormalizedControlValue(); // Move Left/Right
        }

        if(Mathf.Abs(rotateControl.NormalizedControlValue()) > 0.05f)
        {
            transform.Rotate(Vector3.up, rotateControl.NormalizedControlValue() * Time.deltaTime * maxRotateSpeed);
        }
    }
}
