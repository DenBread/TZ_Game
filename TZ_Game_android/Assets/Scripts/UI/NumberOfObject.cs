using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberOfObject : MonoBehaviour
{
    [SerializeField] private Text _txt_Enemy;
    [SerializeField] private Text _txt_Crystal;

    [HideInInspector] public enum ListTexts
    {
        Enemy,
        Crystal
    }

    /// <summary>
    /// Обновляет текст с кол-вом обьектов
    /// </summary>
    /// <param name="number">Кол-во обьектов на данный момент</param>
    /// <param name="maxNumber">Максимальное кол-во обьектов на сцене</param>
    public void UpdateTxt(int number, int maxNumber, ListTexts text)
    {
        if (text == ListTexts.Enemy)
        {
            _txt_Enemy.text = "Enemy: " + number + "/" + maxNumber;
        }

        if (text == ListTexts.Crystal)
        {
            _txt_Crystal.text = "Crystal: " + number + "/" + maxNumber;
        }
    }
}
