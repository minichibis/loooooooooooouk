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

    private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(other.transform.position), Vector3.Distance(transform.position, other.transform.position)))
            {
                
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
