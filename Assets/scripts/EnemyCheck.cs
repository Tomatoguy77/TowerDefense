using UnityEngine;
using System.Collections;

public class EnemyCheck : MonoBehaviour {
    private bool inRange;
    private Vector2 Pos;

    void start() {
        Pos = transform.position;
    }
    void FixedUpdate() {
        inRange = Physics2D.OverlapCircle(Pos,1f);
        if (inRange == true)
        {
            Debug.Log("circle");
        }

    }
        
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
            Debug.Log("fire");
        }
    }
}
