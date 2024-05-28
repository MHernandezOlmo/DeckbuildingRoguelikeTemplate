using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Relic5 : RelicEffect
{
    public Relic5()
    {

    }
    
    public override void ApplyEffect(GameCharacter character)
    {
        HeroController.Instance.Character.OnPostDamageReceived+=()=>
        {
            HeroController.Instance.Character.LastAttacker.ReceiveDamage(5);
        };
    }
}