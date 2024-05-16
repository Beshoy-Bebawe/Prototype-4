using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketFollow : MonoBehaviour
{

    private float powerupStrength = 20;

    Transform enemy;



    // Update is called once per frame
    void Update()
    {
        if(enemy != null)
        {
            transform.LookAt(enemy);
            transform.position = Vector3.MoveTowards(transform.position,enemy.position, powerupStrength * Time.deltaTime);
        }

        

    }

    public void FindEnemy(Transform enemyPos)
    {
        enemy = enemyPos;
        Destroy(gameObject ,5);

    }
    private void OnCollisionEnter(Collision collision)
    {
       
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
                Vector3 awayFromPlayer =(collision.gameObject.transform.position - transform.position);

            
            enemyRigidbody.AddForce(awayFromPlayer * powerupStrength ,ForceMode.Impulse); 
            }



       
    }
}
