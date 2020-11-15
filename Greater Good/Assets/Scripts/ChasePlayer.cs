/*
 * Gregory Blevins
 * Project 4
 * Controls Monster Memory and Pathing
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    Vector3 lastKnownPosition;
    public Vector3 startArea;

    private bool gettingBored = false;
    public float boredTimer = 100f, boredomDelay = 3f;
    float timerHolder, boredomDelayHolder;

    FollowPlayerMainMonster monsterTarget;

    // Start is called before the first frame update
    void Start()
    {
        timerHolder = boredTimer;
        boredomDelayHolder = boredomDelay;

        lastKnownPosition = transform.position;

        startArea = transform.position;

        monsterTarget = FindObjectOfType<FollowPlayerMainMonster>();
    }

    // Update is called once per frame
    void Update()
    {
        SensoryPriority();

        if (gettingBored == true)
        {
            boredTimer -= 1 * Time.deltaTime;
        }
        boredomDelay -= 1 * Time.deltaTime;
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
        else if (boredTimer<=(timerHolder/2))
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
            return true;
        }

        monsterTarget.UpdateTargetbyNode();

        return false;
    }
}
