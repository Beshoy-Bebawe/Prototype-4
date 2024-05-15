using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketFollow : MonoBehaviour
{
    private Rigidbody rocketrb;
    private EnemyScript[] enemy;
    private float powerupStrength = 20;

    // Start is called before the first frame update
    void Awake()
    {
        rocketrb = GetComponent<Rigidbody>();
        enemy = FindObjectsOfType<EnemyScript>();
       
    }
    // Update is called once per frame
    void Update()
    {
      for( int i = 0 ; i <= enemy.Length ; i++)
        { 
            rocketrb.AddForce(enemy[i].transform.position * 10);
        }
        

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
