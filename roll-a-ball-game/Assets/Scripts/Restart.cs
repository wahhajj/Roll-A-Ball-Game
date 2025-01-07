using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RestartGame(); // Restart the game when the space bar is pressed
        }
        if(Input.GetKeyDown(KeyCode.M) || Input.GetKeyDown(KeyCode.Escape)) 
        {
            MainMenu();
        }
    }
    public void RestartGame()
    {
        
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
