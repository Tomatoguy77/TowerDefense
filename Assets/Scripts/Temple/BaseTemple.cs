using UnityEngine;
using System.Collections;

public class BaseTemple : MonoBehaviour
{
    [SerializeField] private GameObject _healthBar;
    [SerializeField] private GameObject _defeat;
    public float health = 100f;

    void Start()
    {
        Time.timeScale = 1;
    }

	void Update ()
    {
        _healthBar.transform.localScale = new Vector3(health / 100, 1, 0);

        if (health <= 0)
        {
            _defeat.SetActive(true);
            _healthBar.SetActive(false);
        }
	}
}
