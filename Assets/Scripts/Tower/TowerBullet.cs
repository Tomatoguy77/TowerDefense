using UnityEngine;
using System.Collections;

public class TowerBullet : MonoBehaviour
{
    private GameObject _target;

    public void SetTarget(GameObject obj)
    {
        _target = obj;
    }

    void Update()
    {
        //If the target is found; move the bullet towards the target.
        if (_target.gameObject != null)
        {
            this.transform.position = Vector2.MoveTowards(transform.position, _target.transform.position, 3 * Time.deltaTime);

            if (this.transform.position == _target.transform.position)
            {
                _target.GetComponent<Enemy>().health -= 50;
                Destroy(this.gameObject);
            }
        }

        //When the Bullet target is not found; destroy this bullet.
        else
        {
            Destroy(this.gameObject);
        }
    }
}
