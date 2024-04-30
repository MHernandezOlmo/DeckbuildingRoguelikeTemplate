using System;
using System.Collections;
using UnityEngine;

public abstract class GameCharacter : MonoBehaviour, IDamageDealer
{
    protected int _currentHealth;
    protected int _maxHealth;
    protected bool _isAlive;
    
    public void DealDamage(IGameCharacter target, int amount)
    {
        throw new NotImplementedException();
    }

    public int Damage { get; set; }
}