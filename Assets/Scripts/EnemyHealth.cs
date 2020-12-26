using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float _hitPoints = 100;

    bool _isDead = false;

    public bool IsDead()
    {
        return _isDead;
    }

    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");
        _hitPoints -= damage;
        Debug.Log("Enemy taking hits");
        if (_hitPoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (_isDead) return;
        _isDead = true;
        GetComponent<Animator>().SetTrigger("die");
    }

}
