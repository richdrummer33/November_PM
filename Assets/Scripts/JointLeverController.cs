using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointLeverController : MonoBehaviour
{
    HingeJoint myJoint;

    // Start is called before the first frame update
    void Start()
    {
        myJoint = GetComponent<HingeJoint>();
    }

    public float NormalizedControlValue() // Calculates and returns a number between -1 and +1 
    {
        float normalizedAngle = myJoint.angle / myJoint.limits.max;

        return normalizedAngle;
    }
}
