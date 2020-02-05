using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WreckingBallExplode : MonoBehaviour
{
    ParticleSystem explosionParticles;

    // Start is called before the first frame update
    void Start()
    {
        explosionParticles = GetComponentInChildren<ParticleSystem>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 1f && explosionParticles.isPlaying == false)
        {
            explosionParticles.Play();
        }
    }
}
