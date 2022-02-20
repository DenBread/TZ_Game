using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawn : MonoBehaviour
{
    private int _countEnemy;
    [Header("Кол-во секунд для спавна врага")]
    [SerializeField] private float _timeSpawn;
    [Header("Максимальное кол-во врагов")]
    [SerializeField] private int _maxCountEnemy;
    [SerializeField] private GameObject _enemyPrefabs;
    [SerializeField] private Transform[] _spawnPoints;

    private void Start()
    {
        StartCoroutine(SpawnRepetition());
    }

    public void Spawn()
    {
        if (_countEnemy < _maxCountEnemy)
        {
            _countEnemy++;
            int randomPoint = Random.Range(0, _spawnPoints.GetLength(0));
            GameObject enemy = Instantiate(_enemyPrefabs, _spawnPoints[randomPoint].position, Quaternion.identity);
        }
    }

    private IEnumerator SpawnRepetition()
    {
        while (_countEnemy <_maxCountEnemy)
        {
            Spawn();
            yield return new WaitForSeconds(_timeSpawn);
        }
    }
}
