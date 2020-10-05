﻿/*
 * Gregory Blevins
 * Project 2
 * Controls the loss condition
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    PlayerController[] possiblePlayers;

    public Image gameOverImage;

    int activePlayers;

    public bool GameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        possiblePlayers = FindObjectsOfType<PlayerController>();

        activePlayers = possiblePlayers.Length;

        for (int i = 0; i<possiblePlayers.Length; i++)
        {
            if (possiblePlayers[i].isPlayable == false)
            {
                activePlayers--;
            }
        }
    }

    public void ReducePlayer()
    {
        activePlayers--;


        if (activePlayers <= 0)
        {
            GameLoss();
        }
    }

    public void IncreasePlayer()
    {
        activePlayers++;
    }

    void GameLoss()
    {
        GameOver = true;
        gameOverImage.gameObject.SetActive(true);
    }
}
