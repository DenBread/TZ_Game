using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerLocator : MonoBehaviour
{
    [SerializeField] private EnemySpawn _enemySpawn;
    [SerializeField] private CrystalSpawn _crystalSpawn;
    [SerializeField] private Transform _arrowEnemy;
    [SerializeField] private Transform _arraowCrystal;
    [SerializeField] private float _speedArraw;

    private void Awake()
    {
        if (_enemySpawn == null)
        {
            _enemySpawn = FindObjectOfType<EnemySpawn>();
        }
        
    }

    private void Start()
    {
        StartCoroutine(FindCloseEnemy());
        StartCoroutine(FindCloseCrystal());
    }

    private void ArrowOnEnemy(GameObject gmEnemy)
    {
        Vector3 diretion = gmEnemy.transform.position - transform.position;
        float angel = Mathf.Atan2(diretion.x, diretion.z) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angel, Vector3.forward);
        _arrowEnemy.rotation = Quaternion.Slerp(_arrowEnemy.rotation, rotation, _speedArraw * Time.deltaTime);
    }
    
    private void ArrowOnCrystal(GameObject gmCrystal)
    {
        if (gmCrystal != null)
        {
            Vector3 diretion = gmCrystal.transform.position - transform.position;
            float angel = Mathf.Atan2(diretion.x, diretion.z) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angel, Vector3.forward);
            _arraowCrystal.rotation = Quaternion.Slerp(_arraowCrystal.rotation, rotation, _speedArraw * Time.deltaTime);
        }
        else
        {
            //Debug.LogError("Кристалл не создался!");
        }
    }

    private IEnumerator FindCloseEnemy()
    {
        while (true)
        {
            float distanceToClosesEnemy = Mathf.Infinity;
            GameObject closeEnemy = null;

            foreach (var currentEnemy in _enemySpawn.Enemies)
            {
                float distanceToEnemy = (currentEnemy.transform.position - transform.position).sqrMagnitude;
                if (distanceToEnemy < distanceToClosesEnemy)
                {
                    distanceToClosesEnemy = distanceToEnemy;
                    closeEnemy = currentEnemy;
                }
            }
            ArrowOnEnemy(closeEnemy);
            Debug.DrawLine(transform.position, closeEnemy.transform.position, Color.yellow, 10f);

            yield return null;
        }
    }

    private IEnumerator FindCloseCrystal()
    {
        while (true)
        {
            float distanceToClosesCrystal = Mathf.Infinity;
            GameObject closeCrystal = null;

            if (_crystalSpawn.CountCrystal != 0)
            {
                _arraowCrystal.gameObject.SetActive(true);
                foreach (var currentCrystal in _crystalSpawn.AllCrystal)
                {
                    float distanceToCrystal = (currentCrystal.transform.position - transform.position).sqrMagnitude;
                    if (distanceToCrystal < distanceToClosesCrystal)
                    {
                        distanceToClosesCrystal = distanceToCrystal;
                        closeCrystal = currentCrystal;
                    }
                }
            }
            else
            {
                _arraowCrystal.gameObject.SetActive(false);
            }
            
            ArrowOnCrystal(closeCrystal);

            yield return null;
        }
    }
}
