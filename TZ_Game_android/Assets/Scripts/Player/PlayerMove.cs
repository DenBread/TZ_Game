using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMove : MonoBehaviour
{
    private Camera _mainCamera;
    private NavMeshAgent _agent;
    private PlayerAnimation _playerAnimation;
    private bool _isRun;
    [SerializeField] private float _speed;

    private void Start()
    {
        _mainCamera = Camera.main;
        _agent = GetComponent<NavMeshAgent>();
        _playerAnimation = GetComponent<PlayerAnimation>();
        _agent.speed = _speed;
    }

    private void Update()
    {
        MoouseTap();
        Move();
    }

    private void MoouseTap()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(_mainCamera.ScreenPointToRay(Input.mousePosition), out hit))
            {
                _agent.SetDestination(hit.point);
            }
        }
    }

    private void Move()
    {

        if (_agent.remainingDistance > _agent.stoppingDistance)
        {
            _playerAnimation.Run();
        }
        else
        {
            _playerAnimation.Idle();
        }
    }
}
