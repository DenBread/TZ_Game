using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lose : MonoBehaviour
{

    [SerializeField] private GameObject _panelLose;

    public void ShowPanelLose()
    {
        _panelLose.SetActive(true);
    }

    public void AgainPlay()
    {
        
    }

    public void ShowMenu()
    {
        SceneManager.LoadScene(0);
    }
}
