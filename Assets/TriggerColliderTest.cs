using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerColliderTest : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(this.gameObject.name + " trigger collided with (sensed) " + other.name);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(this.gameObject.name + " trigger collided with (non-trigger) " + collision.gameObject.name);
    }
}
