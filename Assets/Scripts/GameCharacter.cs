using System;
using System.Collections;
using UnityEngine;

public abstract class GameCharacter : MonoBehaviour
{
    protected int _currentHealth;
    protected int _maxHealth;
    protected bool _isAlive;

    public Action OnHpChanged;
    
    public void ReceiveDamage(int damage)
    {
        if (!_isAlive) return;
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            _isAlive = true;
            StartCoroutine(WaitAndDie());
        }
    }

    protected void Die()
    {
        Destroy(gameObject);
    }
    
    protected abstract IEnumerator WaitAndDie();
    
}