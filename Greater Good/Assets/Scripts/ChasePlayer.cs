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
    Vector3 startArea;

    private bool gettingBored = false;
    public float boredTimer = 100f;
    float timerHolder;

    // Start is called before the first frame update
    void Start()
    {
        timerHolder = boredTimer;
    }

    // Update is called once per frame
    void Update()
    {
        sensoryPriority();

        if (gettingBored == true)
        {
            boredTimer -= 1 * Time.deltaTime;
        }
    }

    //Determines if the monster can find the player
    void sensoryPriority()
    {

        if (doISee())
        {

        }
        else if (doIHear())
        {

        }
        else if (gotBored())
        {
            lastKnownPosition = startArea;
            boredTimer = timerHolder;
        }
        else
        {
            gettingBored = false;
        }

    }

    //Handles the "sight range" of the monster
    private bool doISee()
    {

        if(false) //Insert sight code here
        {
            return true;
        }

        return false;
    }

    //Handles the "hearing range" of the monster
    private bool doIHear()
    {

        if(false) //Insert hearing code here
        {
            return true;
        }

        return false;
    }

    //Handles the "bored" timer of the monster and sends it back to the start if it can't find the player
    private bool gotBored()
    {
        if (boredTimer<=0)
        {
            return true;
        }

        return false;
    }
}
