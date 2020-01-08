using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballLauncher : MonoBehaviour
{
    public GameObject fireballPrefab; // Must refer to the prefab in the assets folder

    public float force = 20f;

    public string triggerAxisName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) || Input.GetAxis(triggerAxisName) > 0.25f) // Check LMB pressed 
        {
            GameObject fireballInstance; // New gameObject empty variable 

            fireballInstance = Instantiate(fireballPrefab, this.transform.position, fireballPrefab.transform.rotation); // Create a copy of fireball prefab (right at the hand position) and provide that GameObject to the fireballInstance variable

            Rigidbody fireballRigidbody = fireballInstance.GetComponent<Rigidbody>(); // Get the rigidbody component

            fireballRigidbody.AddForce(this.transform.forward * force, ForceMode.Impulse); // Add force to the rigidbody of this instance
        }
    }
}
