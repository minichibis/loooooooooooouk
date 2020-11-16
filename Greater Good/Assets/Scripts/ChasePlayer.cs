/*
 * Gregory Blevins
 * Project 5
 * Controls Monster Memory and Pathing
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    Vector3 lastKnownPosition;
    public Vector3 startArea;

    public bool gettingBored = false;
    public float boredTimer = 100f, boredomDelay = 3f;
    float timerHolder, boredomDelayHolder;

    bool gameStarted = false;

    FollowPlayerMainMonster monsterTarget;

    // Start is called before the first frame update
    void Start()
    {
        timerHolder = boredTimer;
        boredomDelayHolder = boredomDelay;

        lastKnownPosition = transform.position;

        monsterTarget = FindObjectOfType<FollowPlayerMainMonster>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted && GameManager.instance.gameStarted)
        {
            gameStarted = true;

            startArea = monsterTarget.currentNode.transform.position;
        }

        if (gameStarted)
        {
            SensoryPriority();

            if (gettingBored == true)
            {
                boredTimer -= 1 * Time.deltaTime;
            }
            boredomDelay -= 1 * Time.deltaTime;
        }
    }

    //Determines if the monster can find the player
    void SensoryPriority()
    {

        if (DoISee(lastKnownPosition))
        {
            
        }
        else if (DoIHear(lastKnownPosition))
        {
            
        }
        else if (boredTimer<=(timerHolder-10))
        {
            GotBored();
        }
        else if (boredomDelay <= 0)
        {
            gettingBored = true;
        }

    }

    //Handles the "sight range" of the monster
    public bool DoISee(Vector3 target)
    {
        if (target!=lastKnownPosition)
        {

            lastKnownPosition = target;

            monsterTarget.UpdateTarget(lastKnownPosition);

            gettingBored = false;

            boredTimer = timerHolder;

            boredomDelay = boredomDelayHolder;

            return true;
        }

        return false;
    }

    //Handles the "hearing range" of the monster
    public bool DoIHear(Vector3 target)
    {

        if (target != lastKnownPosition)
        {

            lastKnownPosition = target;

            monsterTarget.UpdateTarget(lastKnownPosition);

            gettingBored = false;

            boredTimer = timerHolder;

            boredomDelay = boredomDelayHolder;

            return true;
        }

        return false;
    }

    //Handles the "bored" timer of the monster and sends it back to the start if it can't find the player
    private bool GotBored()
    {
        if (boredTimer<=0)
        {
            monsterTarget.UpdateTargetbyNode(true);
            lastKnownPosition = startArea;
            return true;
        }

        monsterTarget.UpdateTargetbyNode(false);

        return false;
    }
}
