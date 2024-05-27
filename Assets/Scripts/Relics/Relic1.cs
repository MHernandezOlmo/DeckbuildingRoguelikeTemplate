using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Relic1 : RelicEffect
{
    public Relic1()
    {
        BattleController.OnCombatStart+=()=>
        {
            HeroController.Instance.Character.Block += 30;
        };
    }
    
    
    
    public override void ApplyEffect(GameCharacter character)
    {
        
    }
}