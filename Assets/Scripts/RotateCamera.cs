using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed; // define the rotationSpeed to speed
     
     
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // definning the Input to the key of horizontal.
        transform.Rotate(Vector3.up , horizontalInput * rotationSpeed * Time.deltaTime); // the thing that moves the camera if key is pressed.
    }
}
