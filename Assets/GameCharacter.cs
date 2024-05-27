using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using Random = UnityEngine.Random;


public class GameCharacter : IDamageDealer, IDamageReceiver
{
    public int Damage { get; set; }

    private int _currentHealth;
    public int CurrentHealth
    {
        get=> _currentHealth;
        set
        {
            _currentHealth = value;
            OnHealthChanged.Invoke(CurrentHealth, MaxHealth);
        }
    }

    public int MaxHealth { get; set; }
    public Action<int, int> OnHealthChanged = delegate(int i, int i1) {  };
    public Action OnDie = delegate {  };
    private IDamageDealer _currentDamageDealer;
    public int Block { get; set;}
    public Action OnPreDamage;
    public GameCharacter(int maxHealth)
    {
        MaxHealth = maxHealth;
        _currentDamageDealer = this;
        Block = 0;
    }
    public void Heal(int amount)
    {
        CurrentHealth += amount;
        if (CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }
    }
    public void DealDamage(GameCharacter target, int amount)
    {
        Debug.Log($"Daño final " + amount);
        target.ReceiveDamage(amount);
    }
    
    public void AddDamageDecorator(DamageModifierDecorator damageBoostDecorator)
    {
        damageBoostDecorator.SetDamageDealerToBeWrapped(_currentDamageDealer);
        _currentDamageDealer = damageBoostDecorator;
    }

    public void ReceiveDamage(int amount)
    {
        Debug.Log($"Vale, me hisieron {amount}");
        CurrentHealth -= amount;
        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            OnDie.Invoke();
        }
    }
    
}
