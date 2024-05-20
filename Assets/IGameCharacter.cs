using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class IGameCharacter : IDamageDealer, IDamageReceiver
{
    public int Damage { get; set; }
    public int CurrentHealth { get; set; }
    public int MaxHealth { get; set; }
    public Action<int, int> OnHealthChanged;
    public Action OnDie;
    public IGameCharacter(int maxHealth)
    {
        MaxHealth = maxHealth;
        CurrentHealth = maxHealth;
    }
    public void DealDamage(IGameCharacter target, int amount)
    {
        target.ReceiveDamage(amount);
        Debug.Log($"Le hago {amount} de daño al puto");
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
