using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEnemy : GameCharacter
{
    [SerializeField] private SOEnemy _enemy;
    public static Action<BattleEnemy> OnEnemyCreated;
    public static Action<BattleEnemy> OnEnemyDied;
    void Start()
    {
        _maxHealth = _enemy.MaxHP;
        _currentHealth = _enemy.MaxHP;
        OnEnemyCreated.Invoke(this);
    }





    

    protected override IEnumerator WaitAndDie()
    {
        OnEnemyDied.Invoke(this);
        yield return new WaitForSeconds(1);
        Die();
    }
}