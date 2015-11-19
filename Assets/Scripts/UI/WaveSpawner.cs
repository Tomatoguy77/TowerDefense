using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaveSpawner : MonoBehaviour
{
    private int _waveLevel = 0;
    [SerializeField] private GameObject _orc;
    private bool _waveActive = false;
    private List<GameObject> _enemies;

    void Start()
    {
        _enemies = new List<GameObject>();

        for(int i = 0; i < 6; i++)
        {
            _enemies.Add(_orc);
        }
    }

    void Update()
    {
        if (_waveActive)
        {
            switch(_waveLevel)
            {
                case 1:
                    print("Wave 1 START");
                    StartCoroutine("SpawnWave");
                    _waveActive = false;
                    break;

                case 2:
                    print("Wave 2 START");
                    StartCoroutine("SpawnWave");
                    _waveActive = false;
                    break;
                    
                case 3:
                    print("Wave 3 START");
                    _waveActive = false;
                    break;
            }
        }
    }

    IEnumerator SpawnWave()
    {
        foreach (var spawnObject in _enemies)
        {
            GameObject instanceObject = Instantiate(spawnObject, spawnObject.transform.position, spawnObject.transform.rotation) as GameObject;
            yield return new WaitForSeconds(1.5f);
        }
    }

    public void StartWave()
    {
        _waveActive = true;
        _waveLevel += 1;
    }

    public void StopWave()
    {
        _waveActive = false;
    }
}
