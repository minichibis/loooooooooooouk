/*
 * Gregory Blevins
 * Project 5 (Greater Good)
 * Controls Monster Sight
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSight : MonoBehaviour
{
    // Start is called before the first frame update

    RaycastHit hit;

    ChasePlayer monsterSight;

    Vector3 playerPosition;



    void Start()
    {
        monsterSight = FindObjectOfType<ChasePlayer>();
    }

    private void OnTriggerEnter(Collider other)
    {

        playerPosition = FindObjectOfType<PlayerController>().gameObject.transform.position;

        if (other.CompareTag("Player") && !other.CompareTag("Obstacles"))
        {
            
            if (Physics.Raycast(transform.position, transform.TransformDirection(other.transform.position), out hit ,Vector3.Distance(transform.position, other.transform.position)) && hit.transform.tag != "Obstacle")
            {
                monsterSight.doISee(playerPosition);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
