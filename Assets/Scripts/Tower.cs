using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour
{
    [SerializeField] private LayerMask _typeEnemyLayer;
    [SerializeField] private GameObject _bullet;
    //public Collider2D[] _checkForEnemy;
    private GameObject _lastHitObject;
    private Vector2 _towerPos;
    private float _shootCooldown = 1.5f;

    void Start()
    {
        _towerPos = transform.position;
        InvokeRepeating("FindGroundEnemy", 0, _shootCooldown);
    }

    void FindGroundEnemy()
    {
        Collider2D[] _checkForEnemy = Physics2D.OverlapCircleAll(_towerPos, 2f, _typeEnemyLayer);

        if(_checkForEnemy[0] != null)
        {
            _lastHitObject = _checkForEnemy[0].gameObject;
            ShootBullet();
            _checkForEnemy[0].gameObject.GetComponent<Enemy>().health -= 50;
        }
        
    }
    
    void ShootBullet()
    {
        Instantiate(_bullet, transform.position, transform.rotation);
        //_bullet.transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), _checkForEnemy.gameObject.transform.position, 3 * Time.deltaTime);
    }
    

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_towerPos, 2f);
    }

}