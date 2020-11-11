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
    RaycastHit hit;

    ChasePlayer monsterSight;
    FollowPlayerMainMonster monsterPosition;

    Vector3 playerPosition;



    void Start()
    {
        monsterSight = FindObjectOfType<ChasePlayer>();
        monsterPosition = FindObjectOfType<FollowPlayerMainMonster>();
    }

    private void OnTriggerEnter(Collider other)
    {
        

        playerPosition = FindObjectOfType<PlayerController>().gameObject.transform.position;

        if (other.CompareTag("Player") && !other.CompareTag("Obstacles"))
        {
            
            if (Physics.Raycast(monsterPosition.gameObject.transform.position,playerPosition,out hit))
            {
                Debug.Log("Sight Hit");
                monsterSight.DoISee(playerPosition);
            }
        }
    }
}
