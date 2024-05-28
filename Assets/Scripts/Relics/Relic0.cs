using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Relic0 : RelicEffect
{
    private int relicEffectTime = 0;
    public Relic0()
    {

    }
    public override void ApplyEffect(GameCharacter character)
    {
        relicEffectTime = 0;
        HeroController.Instance.Character.OnPreDamage+=()=>
        {
            if (relicEffectTime < 2)
            {
                HeroController.Instance.HitDamage += 30;
                relicEffectTime++;
            }
        };
    }
}
