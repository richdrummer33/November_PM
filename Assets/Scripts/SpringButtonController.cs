using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringButtonController : MonoBehaviour
{
    public GameObject button;

    private void OnTriggerEnter(Collider other) // Other is the thing that colldied with us
    {
        if(other.gameObject == button) // Check if the button hit       
        {
            GetComponent<AudioSource>().Play(); // Play a sound
        }
    }

}
