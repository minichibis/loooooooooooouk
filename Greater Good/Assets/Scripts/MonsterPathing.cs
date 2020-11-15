using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPathing : MonoBehaviour
{
    public MonsterPathing SouthNode = null, WestNode = null, NorthNode = null, EastNode = null;

    PlayerController targetPlayer;
    ChasePlayer startingPosition;

    Vector3 currentTarget;

    bool zPosition, xPosition, activeNode = false;

    // Start is called before the first frame update
    void Start()
    {
        targetPlayer = FindObjectOfType<PlayerController>();
        startingPosition = FindObjectOfType<ChasePlayer>();
    }

    void MoveToNodePlayer()
    {
        if (transform.position.z > targetPlayer.gameObject.transform.position.z)
        {
            zPosition = true;
        }
        else
        {
            zPosition = false;
        }

        if (transform.position.x > targetPlayer.gameObject.transform.position.x)
        {
            xPosition = true;
        }
        else
        {
            xPosition = false;
        }

        //If the player is North and West
        if (zPosition && xPosition)
        {
            //If the distance North is greater than the distance West
            if (Mathf.Abs(transform.position.z - targetPlayer.gameObject.transform.position.z) > Mathf.Abs(transform.position.x - targetPlayer.gameObject.transform.position.x))
            {
                NorthNode.SetActiveNode();
                SetActiveNode();
            }
            //If the distance West is greater than the distance North
            else
            {
                WestNode.SetActiveNode();
                SetActiveNode();
            }
        }
        //If the player is South and West
        else if (!zPosition && xPosition)
        {
            //If the distance South is greater than the distance West
            if (Mathf.Abs(transform.position.z - targetPlayer.gameObject.transform.position.z) > Mathf.Abs(transform.position.x - targetPlayer.gameObject.transform.position.x))
            {
                SouthNode.SetActiveNode();
                SetActiveNode();
            }
            //If the distance West is greater than the distance South
            else
            {
                WestNode.SetActiveNode();
                SetActiveNode();
            }
        }
        //If the player is North and East
        else if (zPosition && !xPosition)
        {
            //If the distance North is greater than the distance West
            if (Mathf.Abs(transform.position.z - targetPlayer.gameObject.transform.position.z) > Mathf.Abs(transform.position.x - targetPlayer.gameObject.transform.position.x))
            {
                NorthNode.SetActiveNode();
                SetActiveNode();
            }
            //If the distance West is greater than the distance North
            else
            {
                EastNode.SetActiveNode();
                SetActiveNode();
            }
        }
        //If the player is South and East
        else
        {
            //If the distance North is greater than the distance West
            if (Mathf.Abs(transform.position.z - targetPlayer.gameObject.transform.position.z) > Mathf.Abs(transform.position.x - targetPlayer.gameObject.transform.position.x))
            {
                SouthNode.SetActiveNode();
                SetActiveNode();
            }
            //If the distance West is greater than the distance North
            else
            {
                EastNode.SetActiveNode();
                SetActiveNode();
            }
        }
    }

    void MoveToNodeHome()
    {
        if (transform.position.z > startingPosition.startArea.z)
        {
            zPosition = true;
        }
        else
        {
            zPosition = false;
        }

        if (transform.position.x > startingPosition.startArea.x)
        {
            xPosition = true;
        }
        else
        {
            xPosition = false;
        }

        //If the player is North and West
        if (zPosition && xPosition)
        {
            //If the distance North is greater than the distance West
            if (Mathf.Abs(transform.position.z - targetPlayer.gameObject.transform.position.z) > Mathf.Abs(transform.position.x - targetPlayer.gameObject.transform.position.x))
            {

            }
            //If the distance West is greater than the distance North
            else
            {

            }
        }

    }

    public void SetActiveNode()
    {

        if (activeNode)
        {
            activeNode = false;
        }
    }

}
