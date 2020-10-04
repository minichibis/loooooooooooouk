/*
 * The Platform Men (Gregory Blevins)
 * Project 2
 * Handles the flag system
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagScript : MonoBehaviour
{
    LevelController changeLevel;
    public int nextLevel;
    private bool triggered = false;

    // Start is called before the first frame update
    void Start()
    {
        changeLevel = FindObjectOfType<LevelController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Flag Touched");

        if (other.CompareTag("Player") && !triggered)
        {
            triggered = true;
            changeLevel.ChangeLevel(nextLevel);
        }
    }
}
