using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager
{
    public static Action OnPreCombatDamage;
    
    public static void TriggerPreCombatDamage()
    {
        OnPreCombatDamage.Invoke();
    }
}