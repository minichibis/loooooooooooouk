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

    // Start is called before the first frame update
    void Start()
    {
        changeLevel = FindObjectOfType<LevelController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Flag Touched");

        if (collision.CompareTag("Player"))
        {
            changeLevel.ChangeLevel(nextLevel);
        }
    }
}
