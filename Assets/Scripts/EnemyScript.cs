using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour

{
    // Start is called before the first frame update
    public float speed; // declares the speed varablie
    private Rigidbody enemyRb; //says the rigidbody is equal to enemy rigidbody
    private GameObject player; // declares player
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>(); // connect the enemyRb too the compouement connected to the enemy GameObject
        player = GameObject.Find("Player"); // finds the player in the scene
    }

    // Update is called once per frame
    void Update()
    {
         Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce( lookDirection * speed);// adds the force to follow the enemy from a safe distance
        if (transform.position.y < -10)
        {
            Destroy(gameObject);

        }

    }
}
