using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Image_Health _imageHealth;
    [SerializeField] private int _maxHealth;
    [SerializeField] private float _timeImmortality;
    private bool _isImmortality;
    public int Health { get; private set; } = 3;
    

    /// <summary>
    /// Добавляем здоровье
    /// </summary>
    public void AddHealth()
    {
        if (Health < _maxHealth)
        {
            ++Health;
            _imageHealth.OnHealth();
            
        }
    }

    /// <summary>
    /// Отнимаем здоровье
    /// </summary>
    public void DepriveHealth()
    {
        if (Health > 0 && !_isImmortality)
        {
            --Health;
            _imageHealth.OffHealth();
            StartCoroutine(Immortality());
        }
    }

    /// <summary>
    /// Метод влючает невосприимчив к урону на несколько секунд
    /// </summary>
    /// <returns></returns>
    private IEnumerator Immortality()
    {
        _isImmortality = true;
        yield return new WaitForSeconds(_timeImmortality);
        _isImmortality = false;
    }
}
