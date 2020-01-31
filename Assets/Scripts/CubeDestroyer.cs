using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Destructable")
        {
            GameManager._instance.CountCubeDestroyed(); // Tally of how many objects are destroyed - GameManager

            //Destroy(other.gameObject);
        }
    }
}
