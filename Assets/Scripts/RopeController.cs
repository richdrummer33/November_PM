using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeController : MonoBehaviour
{
    public Transform wreckingArm, wreckingBall;

    LineRenderer ropeLine;

    // Start is called before the first frame update
    void Start()
    {
        ropeLine = GetComponent<LineRenderer>();   
    }

    // Update is called once per frame
    void Update()
    {
        ropeLine.SetPosition(0, wreckingArm.position);

        ropeLine.SetPosition(1, wreckingBall.position);
    }
}
