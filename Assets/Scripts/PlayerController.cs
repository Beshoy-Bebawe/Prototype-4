using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour

{
    private float powerupStrength = 15.0f;
    public bool hasPowerup;
    private Rigidbody playerRb; // definfes the rigidbody that is connected to the player.
    public float speed = 5.0f;// defienes speed varabile
    private GameObject focalPoint; // connects the focalpoint to the playercontroller script
    public GameObject powerupIndicator;
    public GameObject Rocket;
     public bool hasPowerup2;
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
        powerupIndicator.transform.position =transform.position + new Vector3( 0,-0.5f , 0);

        if (hasPowerup2 == true && Input.GetKeyDown(KeyCode.X))
        {
            Instantiate(Rocket,transform.position,Rocket.transform.rotation);
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Powerup"))
        {
        hasPowerup = true;
        Destroy(other.gameObject);
        StartCoroutine(PowerupCountdownRoutine());
        powerupIndicator.gameObject.SetActive(true);
        }

        if (other.CompareTag("Powerup2"))
        {
            hasPowerup2 = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
            powerupIndicator.gameObject.SetActive(true);

        }
    

    }
    private void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") &&  hasPowerup)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer =(collision.gameObject.transform.position - transform.position);

            Debug.Log("Collided with" + collision.gameObject.name + "with powerup set to" + hasPowerup);
           enemyRigidbody.AddForce(awayFromPlayer * powerupStrength ,ForceMode.Impulse); 
        }
    }



    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerup = false;
        powerupIndicator.gameObject.SetActive(false);

    }
}
