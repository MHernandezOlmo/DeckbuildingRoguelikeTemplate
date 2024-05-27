using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Relic4 : RelicEffect
{
    public Relic4()
    {

    }
    
    public override void ApplyEffect(GameCharacter character)
    {
        BattleController.OnCombatStart+=()=>
        {
            HeroController.Instance.Character.Heal(20);
        };
    }
}