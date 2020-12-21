using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float _hitPoints = 100;

    // create a public method which reduces hit points by the amount of damage
    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");
        _hitPoints -= damage;
        Debug.Log("Enemy taking hits");
        if (_hitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }

}
