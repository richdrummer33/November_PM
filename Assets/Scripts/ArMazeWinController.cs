using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArMazeWinController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ball")
        {
            GetComponent<AudioSource>().Play(); // Win the game - play a sound

            other.GetComponent<Rigidbody>().AddForce(transform.forward * 20f, ForceMode.Impulse);

            Destroy(other.gameObject, 5f); // Alternative - respawn the ball to play again (CHALLENGE)
        }
    }
}
