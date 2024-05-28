using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Relic11 : RelicEffect
{
    private int attackCount;
    public Relic11()
    {

    }
    
    public override void ApplyEffect(GameCharacter character)
    {
        HeroController.Instance.OnAttack+=()=>
        {
            attackCount++;
            if (attackCount % 10 == 0)
            {
                HeroController.Instance.FinalDamageMultiplier = 2.0f;
            }
        };
    }
}