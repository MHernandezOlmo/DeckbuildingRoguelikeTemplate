using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageDealer
{
    int Damage { get;}

    void DealDamage(GameCharacter target, int amount);
}

