using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IGameCharacter : IDamageDealer
{
    public int Damage { get; set; }
    public void DealDamage(IGameCharacter target, int amount)
    {
        Debug.Log($"Le hago {amount} de daño al puto");
    }

}
