/*
 * Team Platform Men
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
    string[] levels = {"MainMenu", "SampleScene"};

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    //ChangeLevel takes the interger that points to what level is in the above array
    public void ChangeLevel(int level)
    {
        SceneManager.LoadScene(levels[level]);
    }
}
