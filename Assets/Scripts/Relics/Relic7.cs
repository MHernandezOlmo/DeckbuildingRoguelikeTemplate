using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Relic7 : RelicEffect
{
    private int effectTimes;
    
    public Relic7()
    {

    }
    
    public override void ApplyEffect(GameCharacter character)
    {
        PersistenceManager.OnPickRelic+=()=>
        {
            PersistenceManager.Instance.AddGold(9);
        };
    }
}