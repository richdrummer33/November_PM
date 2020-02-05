using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingLeverController : MonoBehaviour
{
    public Transform upperLimit, lowerLimit;

    Vector3 heading;
    Vector3 normazedHeading;
    
    Transform playerHand;

    // Start is called before the first frame update
    void Start()
    {
        heading = upperLimit.position - lowerLimit.position;

        normazedHeading = heading.normalized;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerHand != null)
        {
            Vector3 startToHand = playerHand.position - lowerLimit.position;

            float dotProduct = Vector3.Dot(startToHand, normazedHeading);

            dotProduct = Mathf.Clamp(dotProduct, 0f, heading.magnitude);

            transform.position = lowerLimit.position + normazedHeading * dotProduct;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<XrGrab>())
        {
            playerHand = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<XrGrab>())
        {
            playerHand = null;
        }
    }
}
