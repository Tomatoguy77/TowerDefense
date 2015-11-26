using UnityEngine;
using System.Collections;

public class EnemyDamage : Enemy {
    

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Collider body = hit.collider;
        Debug.Log(body.tag);
        if (body.tag == "sword")
        {

        }       
        

        
    }

}
