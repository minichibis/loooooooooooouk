using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHearing : MonoBehaviour
{
    RaycastHit hit;

    ChasePlayer monsterHear;

    Vector3 playerPosition;



    void Start()
    {
        monsterHear = FindObjectOfType<ChasePlayer>();
    }

    private void OnTriggerEnter(Collider other)
    {

        playerPosition = FindObjectOfType<PlayerController>().gameObject.transform.position;

        if (other.CompareTag("Player") && !other.CompareTag("Obstacles"))
        {

            if (Physics.Raycast(transform.position, transform.TransformDirection(other.transform.position), out hit, Vector3.Distance(transform.position, other.transform.position)) && hit.transform.tag != "Obstacle")
            {
                monsterHear.doIHear(playerPosition);
            }
        }
    }
}
