using UnityEngine;
using System.Collections;

public class MenuActivator : MonoBehaviour
{
    [SerializeField] private GameObject _howtoObj;
    [SerializeField] private GameObject _creditsObj;
    [SerializeField] private GameObject _menuButtons;
    [SerializeField] private GameObject _returnButton;
    
	public void ShowHowToPlay ()
    {
        _howtoObj.SetActive(true);
        _returnButton.SetActive(true);
        _menuButtons.SetActive(false);
    }

    public void ShowCredits ()
    {
        _creditsObj.SetActive(true);
        _returnButton.SetActive(true);
        _menuButtons.SetActive(false);
    }

    public void ReturnMenu()
    {
        _howtoObj.SetActive(false);
        _creditsObj.SetActive(false);
        _returnButton.SetActive(false);
        _menuButtons.SetActive(true);
    }
}
