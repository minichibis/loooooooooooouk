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

    MonsterPathing[] activeNode;

    public MonsterPathing currentNode;

    ChasePlayer isBored;

    public GameObject currentTarget;
    GameObject tempTarget;
    List<GameObject> silhouetteInstances;
    public float timeBetweenSilhouettes = 5f, timeHolder = 5f;

    void Start()
    {
        isBored = GetComponent<ChasePlayer>();
        activeNode = FindObjectsOfType<MonsterPathing>();
    }

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

    public void UpdateTargetbyNode(bool boredomTest)
    {
        if (boredomTest)
        {
            currentNode.MoveToNodeHome();
            targetPosition = nextNodePosition;
        }
        else
        {
            currentNode.MoveToNodePlayer();
            targetPosition = nextNodePosition;
        }
        
    }

    public void UpdateNodePosition(Vector3 NodeTarget)
    {
        nextNodePosition = NodeTarget;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MovementNode") && !isBored.gettingBored)
        {
            for (int i = 0; i<=activeNode.Length; i++)
            {
                if (activeNode[i].GetActive())
                {
                    if (activeNode[i].transform.position != other.transform.position)
                    {
                        activeNode[i].SetActiveNode();
                    }
                }
                if (other.gameObject == activeNode[i])
                {
                    activeNode[i].SetActiveNode();
                    currentNode = activeNode[i];
                }
            }

        }
    }

    public void RevealTarget()
    {
        Instantiate(currentTarget, targetPosition, currentTarget.transform.rotation);
    }
}
