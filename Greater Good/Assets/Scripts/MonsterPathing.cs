using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPathing : MonoBehaviour
{
    public GameObject SouthNode = null, WestNode = null, NorthNode = null, EastNode = null;

    PlayerController targetPlayer;

    bool zPosition, xPosition;

    // Start is called before the first frame update
    void Start()
    {
        targetPlayer = FindObjectOfType<PlayerController>();
    }

    void FindCorrectMovementNode()
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
    }

    Vector3 SetActiveNode()
    {


        return (transform.position);
    }

}
