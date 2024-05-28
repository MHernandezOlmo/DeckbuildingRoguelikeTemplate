using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Relic10 : RelicEffect
{
    public Relic10()
    {

    }
    
    public override void ApplyEffect(GameCharacter character)
    {
        CombatController.OnEndTurn+=()=>
        {
            if (HeroController.Instance.Character.Block == 0)
            {
                HeroController.Instance.Character.Block = 10;
            }
        };
    }
}