using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Relic2 : RelicEffect
{
    public Relic2()
    {

    }
    
    public override void ApplyEffect(GameCharacter character)
    {
        CombatController.OnPostTargets+=()=>
        {
            if (CombatController.Instance.TargetInfos.Count == 0)
            {
                HeroController.Instance.Character.MaxHealth += 30;
                HeroController.Instance.Character.CurrentHealth += 30;
            }
        };
    }
}