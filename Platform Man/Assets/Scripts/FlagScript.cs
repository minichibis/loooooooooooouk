/*
 * The Platform Men (Gregory Blevins)
 * Project 2
 * Handles the flag system
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlagScript : MonoBehaviour
{
    LevelController changeLevel;
    public int nextLevel;

    public Image gameWinImage;

    bool validLevelChange = false;

    private GameOverController gameOverPrevention;

    // Start is called before the first frame update
    void Start()
    {
        changeLevel = FindObjectOfType<LevelController>();
        gameOverPrevention = FindObjectOfType<GameOverController>();
    }

    void Update()
    {
        if (validLevelChange == true && Input.GetKeyDown(KeyCode.Return))
        {
            changeLevel.ChangeLevel(nextLevel);
        }
        else if (validLevelChange == true && Input.GetKeyDown(KeyCode.R))
        {
            changeLevel.RestartLevel();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") && validLevelChange == false)
        {
            validLevelChange = true;
            gameWinImage.gameObject.SetActive(true);
            gameOverPrevention.IncreasePlayer();
        }
    }
}
