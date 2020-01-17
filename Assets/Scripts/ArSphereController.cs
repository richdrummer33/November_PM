using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArSphereController : MonoBehaviour
{
    Rigidbody thisRigidbody; 

    // Start is called before the first frame update
    void Start()
    {
        thisRigidbody = GetComponent<Rigidbody>(); // Gets the rigidbody from this game object
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0) // Holding the finger down
        {
            RaycastHit raycastHitInfo;

            Ray ray = Camera.current.ScreenPointToRay(Input.GetTouch(0).position);

            if(Physics.Raycast(ray, out raycastHitInfo))
            {
                Vector3 force = raycastHitInfo.point - transform.position;

                thisRigidbody.AddForce(force);
            }
        }
    }
}
