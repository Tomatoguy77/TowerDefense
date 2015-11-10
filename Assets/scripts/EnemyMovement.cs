using UnityEngine;
using System.Collections;
using System;

public class EnemyMovement : MonoBehaviour {
    [SerializeField]
    private float speed;
    [SerializeField]
    private Rigidbody2D rig;
	
	// Update is called once per frame
	void Update () {
        move();
	}

    private void move()
    {
        rig.AddForce(Vector2.right);
    }
}
