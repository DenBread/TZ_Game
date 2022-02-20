using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyCrystal : MonoBehaviour
{
    [SerializeField] private CrystalSpawn _crystalSpawn;

    private void Start()
    {
        _crystalSpawn = FindObjectOfType<CrystalSpawn>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<CrystalRotation>())
        {
            _crystalSpawn.CountCrystal--;
            Destroy(other.gameObject);
        }
    }
}
