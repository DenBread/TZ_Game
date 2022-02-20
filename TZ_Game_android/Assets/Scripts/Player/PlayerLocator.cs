using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerLocator : MonoBehaviour
{
    [SerializeField] private EnemySpawn _enemySpawn;
    private NavMeshAgent _navMeshAgent;

    private void Awake()
    {
        if (_enemySpawn == null)
        {
            _enemySpawn = FindObjectOfType<EnemySpawn>();
        }

        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(GetClosestTarget());
        }
    }

    private IEnumerator GetClosestTarget() {
        while (true)
        {
            float tmpDist = float.MaxValue;
            GameObject currentTarget = null;
            for (int i = 0; i < _enemySpawn.Enemies.Count; i++) {
                if (_navMeshAgent.SetDestination(_enemySpawn.Enemies[i].transform.position)) {
                    //ждем пока вычислится путь до цели
                    while (_navMeshAgent.pathPending) {
                        yield return null;
                    }
                    Debug.Log(_navMeshAgent.pathStatus.ToString());
                    // проверяем, можно ли дойти до цели
                    if (_navMeshAgent.pathStatus != NavMeshPathStatus.PathInvalid) {
                        float pathDistance = 0;
                        //вычисляем длину пути
                        pathDistance += Vector3.Distance(transform.position, _navMeshAgent.path.corners[0]);
                        for (int j = 1; j < _navMeshAgent.path.corners.Length; j++) {
                            pathDistance += Vector3.Distance(_navMeshAgent.path.corners[j - 1], _navMeshAgent.path.corners[j]);
                        }

                        if (tmpDist > pathDistance) { 
                            tmpDist = pathDistance;
                            currentTarget = _enemySpawn.Enemies[i];
                            _navMeshAgent.ResetPath();
                        }
                    } else {
                        Debug.Log("невозможно дойти до "+ _enemySpawn.Enemies[i].name);
                    }

                }

            }
            if (currentTarget != null) {
                //_navMeshAgent.SetDestination(currentTarget.transform.position);
                var heading = currentTarget.transform.position - transform.position;
                var distance = heading.magnitude;

                Debug.Log(distance);
                //... дальше ваша логика движения к цели
            }
        }
    }
}
