﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _medusa;
    [SerializeField] private GameObject _harpy;
    [SerializeField] private GameObject _lastEnemy;
    private LastEnemy _lastEnemyScript;
    private int _waveLevel = 0;
    private bool _waveActive = false;
    private List<GameObject> _enemies;

    void Start()
    {
        _enemies = new List<GameObject>();
        for(int i = 0; i < 3; i++)
        {
            _enemies.Add(_medusa);
        }
    }

    void Update()
    {
        if (_waveActive)
        {
            switch (_waveLevel)
            {
                case 1:
                    StartCoroutine("SpawnWave");
                    _waveActive = false;
                    break;

                case 2:
                    StartCoroutine("SpawnWave");
                    _waveActive = false;
                    break;

                case 3:
                    StartCoroutine("SpawnWave");
                    _waveActive = false;
                    break;
                case 4:
                    StartCoroutine("SpawnWave");
                    _waveActive = false;
                    break;
                case 5:
                    StartCoroutine("SpawnWave");
                    _waveActive = false;
                    break;
                case 6:
                    StartCoroutine("SpawnWave");
                    _waveActive = false;
                    break;
                case 7:
                    StartCoroutine("SpawnWave");
                    _waveActive = false;
                    break;
                case 8:
                    StartCoroutine("SpawnWave");
                    _waveActive = false;
                    break;
                case 9:
                    StartCoroutine("SpawnWave");
                    _waveActive = false;
                    break;
                case 10:
                    StartCoroutine("SpawnWave");
                    _lastEnemy.SetActive(true);
                    _waveActive = false;
                    break;
            }
        }
    }

    IEnumerator SpawnWave()
    {
        switch (_waveLevel)
        {
            case 1:
                _enemies.Add(_harpy);
                _enemies.Add(_medusa);
                break;

            case 2:
                _enemies.Add(_medusa);
                _enemies.Add(_harpy);
                break;

            case 3:
                _enemies.Add(_medusa);
                break;

            case 4:
                _enemies.Add(_harpy);
                break;

            case 5:
                _enemies.Add(_medusa);
                break;

            case 6:
                _enemies.Add(_harpy);
                break;

            case 7:
                _enemies.Add(_medusa);
                break;

            case 8:
                _enemies.Add(_harpy);
                break;

            case 9:
                _enemies.Add(_medusa);
                break;

            case 10:
                
                break;
        }

        foreach (var spawnObject in _enemies)
        {
            GameObject instanceObject = Instantiate(spawnObject, transform.position, transform.rotation) as GameObject;
            yield return new WaitForSeconds(1.5f);
        }
    }

    public void StartWave()
    {
        _waveActive = true;
        GameObject.Find("_WaveCountScript").GetComponent<WaveCount>().waveCounter += 1;
        _waveLevel += 1;
    }

    public void StopWave()
    {
        _waveActive = false;
    }
}
