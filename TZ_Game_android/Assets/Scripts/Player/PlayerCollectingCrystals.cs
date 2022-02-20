using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectingCrystals : MonoBehaviour
{
    [SerializeField] private Account _account;
    [SerializeField] private CrystalSpawn _crystalSpawn;
    private PlayerHealth _playerHealth;

    private void Awake()
    {
        _playerHealth = GetComponent<PlayerHealth>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<CrystalRotation>())
        {
            GameObject gm = other.gameObject;
            _account.AddScore();
            _crystalSpawn.DestroyCrystal(gm);
            _playerHealth.AddHealth();
            Destroy(other.gameObject);
        }
    }
}
