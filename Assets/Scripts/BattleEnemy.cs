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
    public int _actionCounter;
    [SerializeField] private HealthBarWidget _healthBarWidget;
    [SerializeField] private CharacterStatusEffectUIManager _statusEffectUI;
    

    public void SetData()
    {
        
    }

    public void Die()
    {
        FindObjectOfType<EnemiesBattleController>().RemoveEnemy(this);
        Destroy(gameObject);
    }
    

    public int GetNextAction()
    {
        int actionToReturn = _enemy._actionList[_actionCounter];
        _actionCounter++;
        _actionCounter %= _enemy._actionList.Count;
        return actionToReturn;
    }
    void Start()
    {
        _gameCharacter = new IGameCharacter(_enemy.MaxHP);
        _gameCharacter.OnDie += Die;
        _healthBarWidget.SetGameCharacter(_gameCharacter);
        _statusEffectUI.SetCharacter(_gameCharacter);
        OnEnemyCreated.Invoke(this);
    }
}