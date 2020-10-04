/*
 * Team Platform Men (Gregory Blevins)
 * Project 2
 * Controls which level is loaded
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    //This array of scenes of all the levels
    public string[] levels = {"MainMenu", "SampleScene", "Tutorial1", "Tutorial2" , "Tutorial3" , "Tutorial4"};

    int failureCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Restarts the current level
    public void RestartLevel()
    {
        failureCount++;

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    //ChangeLevel takes the interger that points to what level is in the above array
    public void ChangeLevel(int level)
    {
        SceneManager.LoadScene(levels[level]);
    }

    //Exits out of the game
    public void Quit()
    {
        Application.Quit();
    }
}
