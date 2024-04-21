using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEnemy : MonoBehaviour
{
    [SerializeField] private SOEnemy _enemy;
    private int _currentHealth;
    private int _maxHealth;
    [SerializeField] private HealthBarWidget _healthBar;
    public static Action<BattleEnemy> OnEnemyCreated;
    public static Action<BattleEnemy> OnEnemyDied;
    private bool _dead;
    void Start()
    {
        _maxHealth = _enemy.MaxHP;
        _currentHealth = _enemy.MaxHP;
        OnEnemyCreated.Invoke(this);
    }

    public void ReceiveDamage(int damage)
    {
        if (_dead) return;
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            _dead = true;
            StartCoroutine(WaitAndDie());
        }
        _healthBar.RefreshData((float)_currentHealth/(float)_maxHealth);
    }

    private IEnumerator WaitAndDie()
    {
        OnEnemyDied.Invoke(this);
        yield return new WaitForSeconds(1);
        Die();
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
