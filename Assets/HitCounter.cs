using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitCounter : MonoBehaviour
{
    int numHits; // Variable to count the number of times this is hit
    public Text counterText; // To display the number of hits   

    private void OnCollisionEnter(Collision collision) // Increment the count when hit
    {
        if (collision.gameObject.tag == "Projectile") // Comparison
        {
            numHits = numHits + 1;

            counterText.text = "Number of hits: " + numHits;
        }
    }
}
