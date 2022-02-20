using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [Header("Включить паузу в начале игры?")]
    [SerializeField] private bool _isPause;
    
    private void Awake()
    {
        if (_isPause)
        {
            Time.timeScale = 0f;
        }
    }

    /// <summary>
    /// Включает паузу
    /// </summary>
    public void PauseOn()
    {
        Time.timeScale = 0f;
    }

    /// <summary>
    /// Выключает паузу
    /// </summary>
    public void PauseOff()
    {
        Time.timeScale = 1f;

    }
}
