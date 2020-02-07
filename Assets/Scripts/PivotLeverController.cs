using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotLeverController : MonoBehaviour
{
    public Transform upperLimit, lowerLimit;

    Vector3 heading;
    Vector3 normazedHeading;

    public Transform playerHand;

    public Transform pivotPoint;

    Vector3 lookPosition;

    Vector3 centerPos;

    // Start is called before the first frame update
    void Start()
    {
        heading = upperLimit.position - lowerLimit.position;

        normazedHeading = heading.normalized;

        centerPos = transform.position;

        lookPosition = centerPos; // A position above the handle
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHand != null)
        {
            Vector3 startToHand = playerHand.position - lowerLimit.position;

            float dotProduct = Vector3.Dot(startToHand, normazedHeading);

            dotProduct = Mathf.Clamp(dotProduct, 0f, heading.magnitude);

            lookPosition = lowerLimit.position + normazedHeading * dotProduct;
        }
        else
        {
            lookPosition += (centerPos - transform.position) * 2f * Time.deltaTime;
        }

        pivotPoint.LookAt(lookPosition);
    }

    void Grab(Transform hand)
    {
        playerHand = hand;
    }

    void Release()
    {
        playerHand = null;
    }
}
