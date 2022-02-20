using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Image_Health : MonoBehaviour
{
    [SerializeField] private Image[] _images;
    

    /// <summary>
    /// Выключаем сердца в UI
    /// </summary>
    public void OffHealth()
    {
        foreach (var image in _images)
        {
            if (image.gameObject.activeSelf)
            {
                image.gameObject.SetActive(false);
                return;
            }
        }
    }

    /// <summary>
    /// Включаем сердца в UI
    /// </summary>
    public void OnHealth()
    {
        foreach (var image in _images)
        {
            if (image.gameObject.activeSelf == false)
            {
                image.gameObject.SetActive(true);
                return;
            }
        }
    }
}
