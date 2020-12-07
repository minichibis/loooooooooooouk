/*
 * Gregory Blevins
 * Project 6, 7
 * Handles the monster's pathing to the player
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserBehaviour : MonoBehaviour
{
    List<MonsterPathing> previousNodes;

    MonsterPathing setTarget, endNode;

    private int maxPossibleNodes = 12;

    private int currentNode = 0;

    bool updatedNode = false;

    public ChaserBehaviour(MonsterPathing startingNode, MonsterPathing endingNode)
    {
        setTarget = startingNode;

        endNode = endingNode;

        previousNodes.Add(startingNode);
    }

    ChaserBehaviour(int inputNode, List<MonsterPathing> currentNodeList, int movementDirection)
    {
        currentNode = inputNode;

        if (movementDirection == 0 && (setTarget != setTarget.NorthNode))
        {
            setTarget = setTarget.NorthNode;
            updatedNode = true;
        }
        else if (movementDirection == 1 && (setTarget != setTarget.EastNode))
        {
            setTarget = setTarget.EastNode;
            updatedNode = true;
        }
        else if (movementDirection == 2 && (setTarget != setTarget.WestNode))
        {
            setTarget = setTarget.WestNode;
            updatedNode = true;
        }
        else if (movementDirection == 3 && (setTarget != setTarget.SouthNode))
        {
            setTarget = setTarget.SouthNode;
            updatedNode = true;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        MoveToTarget();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MoveToTarget()
    {
        previousNodes.Add(setTarget);

        transform.position = setTarget.transform.position;

        if (currentNode <= maxPossibleNodes && setTarget != endNode)
        {
            for (int i = 0; i < 4; i++)
            {
                ChaserBehaviour temp = new ChaserBehaviour(currentNode + 1, previousNodes, i);
                Instantiate(temp, transform);
            }
        }

        if (setTarget == endNode)
        {

        }

        Destroy(gameObject);
    }

    List<Vector3> PathToTravel()
    {
        List<Vector3> navigationalNodes = new List<Vector3>();

        for (int i = 0; i <= previousNodes.Count; i++)
        {
            navigationalNodes.Add(previousNodes[i].transform.position);
        }

        return navigationalNodes;
    }
}
