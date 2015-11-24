using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _healthBar;
    public int health = 100;
	
	void Update ()
    {
        transform.Translate(Vector2.right * Time.deltaTime);

        if (health == 50)
        {
            _healthBar.transform.localScale = new Vector3(0.8f, 3.2f, 1.6f);
        }

        if (health <= 0)
        {
            print("Enemy Died!");
            Destroy(this.gameObject);
        }
	}
}
