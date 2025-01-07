using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class MainMenuScript : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.Escape)) 
        {
            QuitGame();
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            PlayGame();
        }
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Application.Quit();
        System.Console.WriteLine("Game is quit");
    }






}




  
