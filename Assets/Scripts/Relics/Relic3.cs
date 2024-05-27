using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Relic3 : RelicEffect
{
    private int relicEffectTime = 0;
    public Relic3()
    {
    }
    
    
    
    public override void ApplyEffect(GameCharacter character)
    {
        relicEffectTime = 0;
        BattleController.OnCombatStart+=()=>
        {
            EffectManager.Instance.ApplyEffect(new ActiveStatusEffect(StatusEffects.Artifact,1),EnemiesBattleController.Instance.GetEnemies().ToList());
        };
    }
}