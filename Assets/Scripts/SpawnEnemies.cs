using UnityEngine;
using System.Collections;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] private GameObject _enemyToSpawn;
    
	void Start ()
    {
        InvokeRepeating("Spawn", 0f, 1.5f);
	}

    void Spawn ()
    {
        Instantiate(_enemyToSpawn);
    }

}
