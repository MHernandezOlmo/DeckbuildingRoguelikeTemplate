using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleEnemy : MonoBehaviour
{
    [SerializeField] private SOEnemy _enemy;
    public static Action<BattleEnemy> OnEnemyCreated;
    public static Action<BattleEnemy> OnEnemyDied;
    public IGameCharacter _gameCharacter;
    void Start()
    {
        OnEnemyCreated.Invoke(this);
    }
}