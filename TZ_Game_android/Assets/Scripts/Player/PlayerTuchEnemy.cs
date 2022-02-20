using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTuchEnemy : MonoBehaviour
{
    private PlayerHealth _playerHealth;
    [SerializeField] private Lose _lose;

    private void Awake()
    {
        _playerHealth = GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<EnemyTrigger>())
        {
            _playerHealth.DepriveHealth();

            if (_playerHealth.Health <= 0)
            {
                _lose.ShowPanelLose();
            }
        }
    }
    
}
