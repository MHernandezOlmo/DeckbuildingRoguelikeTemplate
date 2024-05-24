using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelicTest : RelicEffect
{
    private int relicEffectTime = 0;
    public RelicTest()
    {
        relicEffectTime = 0;
        HeroController.Instance.Character.OnPreDamage+=()=>
        {
            if (relicEffectTime < 2)
            {
                Debug.Log("Aplico la reliquia");
                HeroController.Instance.HitDamage += 30;
                relicEffectTime++;
            }
            else
            {
                Debug.Log("Ya he aplicado esto");
            }
        };
    }
    
    
    
    public override void ApplyEffect(GameCharacter character)
    {
        
    }
}
