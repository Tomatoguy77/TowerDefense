using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour
{
    private bool isPaused = false;
    
    public void ShowMenu()
    {
        //If you press the pause button and the game is not paused; pause the game.
        if (isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;
        }

        //If you press the pause button and the game is paused; resume the game.
        else
        {
            if (!isPaused)
            {
                Time.timeScale = 0;
                isPaused = true;
            }
        }
        
    }
}
