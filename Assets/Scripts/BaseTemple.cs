using UnityEngine;
using System.Collections;

public class BaseTemple : MonoBehaviour
{
    [SerializeField] private GameObject _defeat;
    [SerializeField] private GameObject _pauseMenu; //Moet nog invoegen.
    public float health = 100f;

	void Update ()
    {
	    if (health <= 0)
        {
            _pauseMenu.SetActive(false);
            _defeat.SetActive(true);
        }
	}
}
