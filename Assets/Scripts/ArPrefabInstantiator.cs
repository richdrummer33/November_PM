using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ArPrefabInstantiator : MonoBehaviour
{
    public GameObject prefab; // To spawn / instantiate

    GameObject prefabInstance;

    ARRaycastManager raycastManager; 
    
    void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }
    
    void Update()
    {
        if (prefabInstance == null)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) // Check for screen touch. Remove "&& prefabInstance != null" if you want to instantiate multiple prefabs
            {
                Vector2 touchPoint = Input.GetTouch(0).position;

                List<ARRaycastHit> hitResults = new List<ARRaycastHit>();

                if (raycastManager.Raycast(touchPoint, hitResults, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
                {
                    prefabInstance = Instantiate(prefab, hitResults[0].pose.position, prefab.transform.rotation); // hitResults[0].pose.position = the point on the plane that the raycast hit

                    LookAtPlayer();
                }
            }
        }
    }

    void LookAtPlayer() // Tell prefabInstance to look in hte direction of the player (e.g. the Camera.main) 
    {
        Vector3 lookDirection = Camera.main.transform.position - prefabInstance.transform.position;

        Quaternion lookRotation = Quaternion.LookRotation(lookDirection); // New rotation facing the phone/player camera

        Vector3 eulerRotation = new Vector3(prefabInstance.transform.eulerAngles.x, lookRotation.eulerAngles.y, prefabInstance.transform.eulerAngles.z); // Cancel out x and z rotation

        prefabInstance.transform.rotation = Quaternion.Euler(eulerRotation); // Finally applyy the rotation
    }
}
