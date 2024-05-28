using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Relic9 : RelicEffect
{
    private int turnCount;
    
    public Relic9()
    {

    }
    
    public override void ApplyEffect(GameCharacter character)
    {
        CombatController.OnStartTurn+=()=>
        {
            turnCount++;
            if (turnCount % 3 == 0)
            {
                PersistenceManager.Instance.AddGold(10);
            }
        };
    }
}