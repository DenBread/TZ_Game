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
    [SerializeField] private NumberOfObject _numberOfObject;
    public List<GameObject> Enemies { get; private set; } // лист сохраняет врагов, когда они спавняться

    private void Start()
    {
        Enemies = new List<GameObject>();
        StartCoroutine(SpawnRepetition());
    }

    public void Spawn()
    {
        if (_countEnemy < _maxCountEnemy)
        {
            _countEnemy++;
            int randomPoint = Random.Range(0, _spawnPoints.GetLength(0));
            GameObject enemy = Instantiate(_enemyPrefabs, _spawnPoints[randomPoint].position, Quaternion.identity);
            Enemies.Add(enemy);
            _numberOfObject.UpdateTxt(_countEnemy, _maxCountEnemy, NumberOfObject.ListTexts.Enemy);
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
