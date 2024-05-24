using System;
using System.Collections.Generic;
using UnityEngine;

public class PreCombatDamageHandler : MonoBehaviour
{
    private List<ActionEffect> _actionsToApply;

    private void OnEnable()
    {
        EventManager.OnPreCombatDamage += ApplyActions;
    }
    
    private void OnDisable()
    {
        EventManager.OnPreCombatDamage += ApplyActions;
    }
    
    public void AddAction(ActionEffect action)
    {
        if (_actionsToApply == null)
        {
            _actionsToApply = new List<ActionEffect>();
        }
        _actionsToApply.Add(action);
    }

    public void ApplyActions()
    {
        foreach (var action in _actionsToApply)
        {
            action.Action.Invoke();
        }
        _actionsToApply.Clear();
    }
}