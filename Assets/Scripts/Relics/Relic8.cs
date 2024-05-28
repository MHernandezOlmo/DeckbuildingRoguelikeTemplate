using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Relic8 : RelicEffect
{
    private int effectTimes;
    
    public Relic8()
    {

    }
    public override void ApplyEffect(GameCharacter character)
    {
        CombatController.OnStartTurn+=()=>
        {
            if (effectTimes < 1)
            {
                PersistenceManager.Instance.AddGold(5);
                effectTimes++;
            }
        };
    }
}