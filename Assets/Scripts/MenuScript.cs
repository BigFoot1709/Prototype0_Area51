using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            //Press escape key to exit the game
            Application.Quit();
        }
        if (Input.GetKey(KeyCode.R))
        {
            //Press a key to reset the level
            SceneManager.LoadScene("LevelScene");
            //Need the name of the main level scene
        }
    }
    
    public void PlayGame()
    {
        //On Button Press in menu
        SceneManager.LoadScene("LevelScene");
        //Need the name of the main level scene
    }

    public void ExitGame()
    {
        //On Button Press in menu
        Application.Quit();
    }
}
