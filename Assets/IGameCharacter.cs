using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using Random = UnityEngine.Random;


public class IGameCharacter : IDamageDealer, IDamageReceiver
{
    public int Damage { get; set; }
    public int CurrentHealth { get; set; }
    public int MaxHealth { get; set; }
    public Action<int, int> OnHealthChanged = delegate(int i, int i1) {  };
    public Action OnDie = delegate {  };
    private IDamageDealer _currentDamageDealer;

    public void ApplyDamage(IGameCharacter target, int amount)
    {
        _currentDamageDealer.DealDamage(target, amount);
    }
    public IGameCharacter(int maxHealth)
    {
        MaxHealth = maxHealth;
        CurrentHealth = maxHealth;
        _currentDamageDealer = this;
    }
    public void DealDamage(IGameCharacter target, int amount)
    {
        Debug.Log($"Le hago {amount} de daño al puto");
        target.ReceiveDamage(amount);
    }
    
    public void AddDamageDecorator(DamageBoostDecorator damageBoostDecorator)
    {
        damageBoostDecorator.SetDamageDealerToBeWrapped(_currentDamageDealer);
        _currentDamageDealer = damageBoostDecorator;
        Debug.Log($"Damage decorator added with additional damage: {damageBoostDecorator.Damage}");

    }
    
    public void ReceiveDamage(int amount)
    {
        CurrentHealth -= amount;
        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            OnDie.Invoke();
        }
        OnHealthChanged.Invoke(CurrentHealth, MaxHealth);
    }
}
