using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour
{
    [SerializeField] private LayerMask _typeEnemyLayer;
    [SerializeField] private GameObject _bullet;
    private GameObject _closestEnemy;
    private Vector2 _towerPos;
    private float _shootCooldown = 1.5f;
    public float towerRange = 2f;

    void Start()
    {
        _towerPos = transform.position;
        InvokeRepeating("FindGroundEnemy", 0, _shootCooldown);
    }

    void FindGroundEnemy()
    {
        //Search the Collider2D of an enemy with the selected Layer within a certain range.
        Collider2D[] _checkForEnemy = Physics2D.OverlapCircleAll(_towerPos, towerRange, _typeEnemyLayer);

        float shortestDistance = float.MaxValue;
        for (int i = 0; i < _checkForEnemy.Length; i++)
        {
            float distance = Vector2.Distance(_towerPos, _checkForEnemy[i].transform.position);
            if (distance < shortestDistance)
            {
                _closestEnemy = _checkForEnemy[i].gameObject;
                shortestDistance = distance;
            }
        }

        //If the enemy within range has been found; instantiate a bullet.
        if (_closestEnemy != null)
        {
            print("Closest found!");
            ShootBullet();
        }
    }
    
    //Instantiate a bullet prefab.
    void ShootBullet()
    {
        GameObject bulletObj = Instantiate(_bullet, transform.position, transform.rotation) as GameObject;
        bulletObj.GetComponent<TowerBullet>().SetTarget(_closestEnemy);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_towerPos, towerRange);
    }

    /*
    private void OnMouseDown()
    {
        //Activeer een Gameobject en geef die een script om towerRange te upgraden.
    }
    */
}