using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ArPrefabInstantiator : MonoBehaviour
{
    public GameObject prefab; // To spawn / instantiate

    GameObject prefabInstance;

    ARRaycastManager raycast; 
    
    void Start()
    {
        raycast = GetComponent<ARRaycastManager>();
    }
    
    void Update()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && prefabInstance == null) // Check for screen touch. Remove "&& prefabInstance != null" if you want to instantiate multiple prefabs
        {
            Vector2 touchPoint = Input.GetTouch(0).position;

            List<ARRaycastHit> hitResults = new List<ARRaycastHit>();

            if (raycast.Raycast(touchPoint, hitResults, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
            {
                prefabInstance = Instantiate(prefab, hitResults[0].pose.position, prefab.transform.rotation); // hitResults[0].pose.position = the point on the plane that the raycast hit
            }
        }
    }
}
