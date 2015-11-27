using UnityEngine;
using System.Collections;

public class TempleCollision : MonoBehaviour
{
    public virtual void TempleCollide(BaseTemple _BT)
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Check if the collider from the GameObject the temple is.
        var _temple = other.gameObject.GetComponent<BaseTemple>();

        //If this isn't null; we have the temple.
        if (_temple != null)
        {
            TempleCollide(_temple);
        }
    }
}
