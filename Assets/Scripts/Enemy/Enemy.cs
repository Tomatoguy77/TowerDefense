using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public float health = 100;
	
	void Update ()
    {
        transform.Translate(Vector2.right * Time.deltaTime);

        if (health <= 0)
        {
            print("Enemy Died!");
            Destroy(this.gameObject);
        }
	}
}
