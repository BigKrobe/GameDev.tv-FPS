using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float _playerHealth = 100f;

    public void TakeDamage(float damage)
    {
        _playerHealth -= damage;
        if (_playerHealth <= 0)
        {
            GetComponent<DeathHandler>().HandleDeath();
        }
    }
}
