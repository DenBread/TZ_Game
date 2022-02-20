using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lose : MonoBehaviour
{
    
    [SerializeField] private GameObject _panelLose;

    /// <summary>
    /// Показывает панель проигрыша
    /// </summary>
    public void ShowPanelLose()
    {
        _panelLose.SetActive(true);
    }

    /// <summary>
    /// Показывает главное меню
    /// </summary>
    public void ShowMenu()
    {
        SceneManager.LoadScene(0);
    }
}
