using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBoosterRelicEffect : RelicEffect
{
    public override void ApplyEffect(IGameCharacter targetCharacter)
    {
        
        targetCharacter.AddDamageDecorator(new DamageBoostDecorator(20));
        //targetCharacter.AddNewDamageBoostDecorator.Invoke(new DamageBoostDecorator(20));
    }
    
}
