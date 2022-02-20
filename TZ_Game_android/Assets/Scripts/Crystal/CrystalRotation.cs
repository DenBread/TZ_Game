using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalRotation : MonoBehaviour
{
    [Header("Градус поворота")]
    [SerializeField] private float _speed;

    private void Update()
    {
        CrystalRot();
    }

    private void CrystalRot()
    {
        Vector3 vec = Vector3.forward * _speed;
        transform.Rotate(vec * Time.deltaTime);
    }
}
