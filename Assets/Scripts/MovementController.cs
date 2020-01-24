using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public JointLeverController theLeverThatMakesMeMove;

    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + transform.forward * Time.deltaTime * speed * theLeverThatMakesMeMove.NormalizedControlValue();
    }
}
