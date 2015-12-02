using UnityEngine;
using System.Collections;

public class DamageEnemy : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "bullet")
        {
            Destroy(this.gameObject);
        }
    }
}
