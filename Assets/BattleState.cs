using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleState : MonoBehaviour
{
    [SerializeField] private PlayerCharacter _player;
    [SerializeField] private EnemiesBattleController _battleController;
    [SerializeField] private InventoryController _inventory;
    [SerializeField] private CombatAreaController _combatAreaController;
    [SerializeField] private EffectManager _effectManager;
    
    private void Start()
    {
    }

    public void DealDamageToPlayer(int damage)
    {
        
    }

    public void ApplyEffectToCharacter()
    {
        
    }
    
    public void ApplyEffectToAllCharacters()
    {
        
    }

    public void ApplyEffectToPlayerCharacter(IStatusEffect effect)
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
