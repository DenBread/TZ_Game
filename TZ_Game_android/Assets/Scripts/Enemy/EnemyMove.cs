
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class EnemyMove : MonoBehaviour
{
    public NavMeshAgent NavMeshAgent { get; private set; }
    private GameObject _point;
    [Header("Точки для спавна")]
    [SerializeField] private Transform _pointPosition;
    [Header("Скорость перемещения")]
    [SerializeField] private float _speed;
    
    [Header("Предел перемещения по оси X")]
    [SerializeField] private float _x;
    [Header("Предел перемещения по оси Z")]
    [SerializeField] private float _z;

    private void Start()
    {
        NavMeshAgent = GetComponent<NavMeshAgent>();
        NavMeshAgent.speed = _speed;
        _point = Instantiate(_pointPosition.gameObject);
        StartCoroutine(NewPoint());
    }

    private void Update()
    {
        NavMeshAgent.SetDestination(_point.transform.position);
    }

    private IEnumerator NewPoint()
    {
        while (true)
        {
            NewPointPosition();
            yield return new WaitForSeconds(3f);
        }
    }

    private void NewPointPosition()
    {
        float x = Random.Range(-_x, _x);
        float z = Random.Range(-_z, _z);

        
        _point.transform.position = new Vector3(x, transform.position.y, z);
    }
}
