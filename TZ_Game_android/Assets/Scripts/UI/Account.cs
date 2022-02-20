using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Account : MonoBehaviour
{
    private const string _bestScoreKey = "BestScore";
    
    [Header("Текст Txt_Account в PanelGameplay")]
    [SerializeField] private Text textAccount;
    [Header("Текст Txt_Record в PanelStart")]
    [SerializeField] private Text txtBestScoreMenu;
    [Header("Текст Txt_Record в PanelLose")]
    [SerializeField] private Text txtBestScoreLose;
    public int Score { get; private set; } = 0;
    public int BestScore { get; private set; }

    [Header("Минимальное начисления очков")] [SerializeField]
    private int _minScore;
    [Header("Масимальное начисления очков")] [SerializeField]
    private int _maxScore; 

    private void Awake()
    {
        BestScore = PlayerPrefs.GetInt(_bestScoreKey, 0);
        txtBestScoreMenu.text = "Record: " + BestScore;
        txtBestScoreLose.text = "Record: " + BestScore;
        textAccount.text = "Счет: " + Score.ToString();
    }

    /// <summary>
    /// Добавляет рандомные очки за кристалл
    /// </summary>
    public void AddScore()
    {
        Score += Random.Range(_minScore,_maxScore);
        textAccount.text = "Score: " + Score.ToString();
        SaveScore();
    }

    /// <summary>
    /// Сохраняем лучшего счета
    /// </summary>
    private void SaveScore()
    {
        if (Score > BestScore)
        {
            PlayerPrefs.SetInt(_bestScoreKey, Score);
        }
    }
}
