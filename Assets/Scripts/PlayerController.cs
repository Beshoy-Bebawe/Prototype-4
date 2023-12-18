using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb; // definfes the rigidbody that is connected to the player.
    public float speed = 5.0f;// defienes speed varabile
    private GameObject focalPoint; // connects the focalpoint to the playercontroller script
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>(); // connects the definition of the varabile to the compoement of ridgdbody.
        focalPoint = GameObject.Find("Focal Point");// finds the focal point in the scene
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");  // assigns the forwardInput to a GetAxis Key.
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput); // adds force to the player RigidBody with the forwardInput varabile. 
    }
}
