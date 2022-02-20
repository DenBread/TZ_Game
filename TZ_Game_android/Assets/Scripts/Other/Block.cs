using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private CrystalSpawn _crystalSpawn;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<CrystalRotation>())
        {
            Destroy(other.gameObject);
            _crystalSpawn.Spawn();
        }
    }
}
