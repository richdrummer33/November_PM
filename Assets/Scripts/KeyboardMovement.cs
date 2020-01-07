using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardMovement : MonoBehaviour
{
    string myString;

    public int frameCount;

    public float moveSpeed = 20f;

    public float rotationSpeed = 60f;

    // Start is called before the first frame update
    void Start()
    {
        MyMethod();

        myString = "My method is finished running";

        Debug.Log(myString);
    }

    // Update is called once per frame
    void Update()
    {
        frameCount = frameCount + 1; // Increment by 1 every frame

        if( Input.GetKey(KeyCode.W) == true )
        {
            this.transform.position = this.transform.position + transform.forward * Time.deltaTime * moveSpeed; // Some direction and distance
        }
        if (Input.GetKey(KeyCode.A) == true)
        {
            this.transform.position = this.transform.position - transform.right * Time.deltaTime * moveSpeed; // Some direction and distance
        }
        if(Input.GetKey(KeyCode.S) == true)
        {
            this.transform.position = this.transform.position - transform.forward * Time.deltaTime * moveSpeed;
        }
        if(Input.GetKey(KeyCode.D) == true)
        {
            this.transform.position = this.transform.position + transform.right * Time.deltaTime * moveSpeed;
        }

        transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * Time.deltaTime * rotationSpeed, Space.World);

        transform.Rotate(Vector3.left, Input.GetAxis("Mouse Y") * Time.deltaTime * rotationSpeed, Space.Self);
    }

    void MyMethod()
    {
        myString = "MyMethod is running";

        Debug.Log(myString);
    }
}