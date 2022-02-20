using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Account : MonoBehaviour
{
    private const string _bestScoreKey = "BestScore";
    
    [SerializeField] private Text textAccount;
    [SerializeField] private Text txtBestScore;
    public int Score { get; private set; } = 0;
    public int BestScore { get; private set; }

    [Header("Минимальное начисления очков")] [SerializeField]
    private int _minScore;
    [Header("Масимальное начисления очков")] [SerializeField]
    private int _maxScore; 

    private void Awake()
    {
        BestScore = PlayerPrefs.GetInt(_bestScoreKey, 0);
        txtBestScore.text = "Record: " + BestScore;
        textAccount.text = "Счет: " + Score.ToString();
    }

    /// <summary>
    /// Добавляет рандомные очки за кристал
    /// </summary>
    public void AddScore()
    {
        Score += Random.Range(_minScore,_maxScore);
        textAccount.text = "Счет: " + Score.ToString();
        SaveScore();
    }

    /// <summary>
    /// Сохраняем лучший счет
    /// </summary>
    private void SaveScore()
    {
        if (Score > BestScore)
        {
            PlayerPrefs.SetInt(_bestScoreKey, Score);
        }
    }
}
