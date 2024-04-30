using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBoosterRelicEffect : RelicEffect
{
    public override void ApplyEffect()
    {
         HeroController.AddNewDamageBoostDecorator.Invoke(new DamageBoostDecorator(20));
    }
}
