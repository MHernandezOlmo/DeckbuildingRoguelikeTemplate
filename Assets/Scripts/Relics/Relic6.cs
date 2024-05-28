using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Relic6 : RelicEffect
{
    private int effectTimes;
    public Relic6()
    {

    }
    
    public override void ApplyEffect(GameCharacter character)
    {
        HeroController.Instance.Character.OnHealthChanged+=()=>
        {
            if (effectTimes < 1)
            {
                effectTimes++;
                //Do something
            }
        };
    }
}