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
    private string name;
    
    public IGameCharacter(int maxHealth)
    {
        name = Random.Range(0, 1000).ToString();
        MaxHealth = maxHealth;
        CurrentHealth = maxHealth;
        _currentDamageDealer = this;
    }
    public void DealDamage(IGameCharacter target, int amount)
    {
        
        target.ReceiveDamage(amount);
        Debug.Log($"Soy {name} y Le hago {amount} de daño al puto");
    }
    
    public void AddDamageDecorator(DamageBoostDecorator damageBoostDecorator)
    {
        damageBoostDecorator.SetDamageDealerToBeWrapped(_currentDamageDealer);
        _currentDamageDealer = damageBoostDecorator;
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
