using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketFollow : MonoBehaviour
{
    private Rigidbody rocketrb;
    private EnemyScript[] enemy;

    // Start is called before the first frame update
    void Awake()
    {
        rocketrb = GetComponent<Rigidbody>();
        enemy = FindObjectsOfType<EnemyScript>();
        for(int i = 0; i <= enemy.Length ; i++)
        {
            Vector3 enemyposition = enemy[i].transform.position;

        }
    }
    // Update is called once per frame
    void Update()
    {
        

    }
    private void OnCollisionEnter(Collision collision)
    {

    }
}
