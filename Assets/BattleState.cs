using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleState : MonoBehaviour
{
    [SerializeField] private PlayerCharacter _player;
    [SerializeField] private EnemiesBattleController _battleController;
    
    public void DealDamageToPlayer(int damage)
    {
    }
    
    public void DealDamageToAllEnemies(int damage)
    {
        _battleController.DealDamageToAllEnemies(damage);
    }

    public void DealDamageToOneEnemy(int targetEnemy, int damage)
    {
        
    }
}