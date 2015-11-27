using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour
{
    [SerializeField] private LayerMask _typeEnemyLayer;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _zeusHand;
    private Animator _animator;
    private GameObject _closestEnemy;
    private Vector2 _towerPos;
    private Vector2 _bulletPos;
    private float _shootCooldown = 1.5f;
    public float towerRange = 2f;

    void Start()
    {
        _towerPos = transform.position;
        _bulletPos = _zeusHand.transform.position;
        _animator = GetComponent<Animator>();
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
            _animator.SetBool("isAttacking", true);
            ShootBullet();
        }

        else
        {
            _animator.SetBool("isAttacking", false);
        }
    }
    
    //Instantiate a bullet prefab.
    void ShootBullet()
    {
        GameObject bulletObj = Instantiate(_bullet, _bulletPos, transform.rotation) as GameObject;
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