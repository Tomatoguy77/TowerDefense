using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour
{
    private bool isPaused = false;
    [SerializeField] private GameObject _menuPopup;

    public void ShowMenu()
    {
        //If you press the pause button and the game is not paused; pause the game.
        if (isPaused)
        {
            _menuPopup.SetActive(false);
            Time.timeScale = 1;
            isPaused = false;
        }

        //If you press the pause button and the game is paused; resume the game.
        else
        {
            if (!isPaused)
            {
                _menuPopup.SetActive(true);
                Time.timeScale = 0;
                isPaused = true;
            }
        }
    }
    
    public void Resume()
    {
        _menuPopup.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }   
}
