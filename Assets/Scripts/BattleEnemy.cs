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
    public List<int> GetActionList()
    {
        return _enemy._actionList;
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
        OnEnemyCreated.Invoke(this);
    }
}