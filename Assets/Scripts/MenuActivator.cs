using UnityEngine;
using System.Collections;

public class MenuActivator : MonoBehaviour
{
    [SerializeField]
    private GameObject _howtoObjs;
    [SerializeField]
    private GameObject _creditsObjs;
    
	public void ShowHowToPlay ()
    {
        _howtoObjs.SetActive(true);
        _creditsObjs.SetActive(false);
	}

    public void ShowCredits ()
    {
        _howtoObjs.SetActive(false);
        _creditsObjs.SetActive(true);
	}
}
