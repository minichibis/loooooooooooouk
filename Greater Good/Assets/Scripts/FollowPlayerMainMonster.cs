/*
 * Gregory Blevins
 * Project 5
 * Controls targetting and monster movement
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerMainMonster : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    Vector3 targetPosition, nextNodePosition;


    public GameObject currentTarget;
    GameObject tempTarget;
    List<GameObject> silhouetteInstances;
    public float timeBetweenSilhouettes = 5f, timeHolder = 5f;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(targetPosition);

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        timeHolder -= 1 * Time.deltaTime;
    }

    public void UpdateTarget(Vector3 updatedPosition)
    {
        targetPosition = updatedPosition;

        if (timeHolder <= 0)
        {
            RevealTarget();

            timeHolder = timeBetweenSilhouettes;
        }
    }

    public void UpdateTargetbyNode()
    {
        targetPosition = nextNodePosition;
    }

    public void RevealTarget()
    {
        Instantiate(currentTarget, targetPosition, currentTarget.transform.rotation);
    }
}
