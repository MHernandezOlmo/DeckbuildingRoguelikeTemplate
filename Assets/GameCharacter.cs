using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using Random = UnityEngine.Random;


public class GameCharacter : IDamageDealer, IDamageReceiver
{
    public int Damage { get; set; }
    public int CurrentHealth { get; set; }
    public int MaxHealth { get; set; }
    public Action<int, int> OnHealthChanged = delegate(int i, int i1) {  };
    public Action OnDie = delegate {  };
    private IDamageDealer _currentDamageDealer;

    public Action OnPreDamage;
    public void ApplyDamage(GameCharacter target, int amount)
    {
        _currentDamageDealer.DealDamage(target, amount);
    }
    public GameCharacter(int maxHealth)
    {
        MaxHealth = maxHealth;
        CurrentHealth = maxHealth;
        _currentDamageDealer = this;
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
        OnHealthChanged.Invoke(CurrentHealth, MaxHealth);
    }
}
