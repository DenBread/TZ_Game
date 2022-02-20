using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class CrystalSpawn : MonoBehaviour
{
    [SerializeField] private float _x;
    [SerializeField] private float _z;
    [SerializeField] private GameObject _crystalPrefab;
    public int CountCrystal { get; set; }
    private bool _isSpawn = true;
    
    [Header("Максимальное кол-во кристалов на сцене")]
    [SerializeField] private int _maxCrystal;
    [Header("Время через которое появляеться кристалл в секундах")]
    [SerializeField] private float _timeSpawn;
    
 
    private void Start()
    {
        StartCoroutine(SpawnRepetition());
        for (int i = 1; i < _maxCrystal; i++)
        {
            Spawn();
        }
    }

    private IEnumerator SpawnRepetition()
    {
        while (_isSpawn)
        {
            if (CountCrystal <= _maxCrystal)
            {
                Spawn();
            }
            yield return new WaitForSeconds(_timeSpawn);
        }
    }

    public void Spawn()
    {
        if (CountCrystal > _maxCrystal)
        {
            CountCrystal = _maxCrystal;
        }
        
        CountCrystal++;
        Vector3 vec = new Vector3(Random.Range(-_x, _x), transform.position.y, Random.Range(-_z, _z));
        GameObject gm = Instantiate(_crystalPrefab, vec, Quaternion.Euler(90, 0, 0));
    }
    
}
