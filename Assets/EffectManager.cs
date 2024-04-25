using System;using System.Collections.Generic;
using UnityEngine;

public class EffectManager
{
    private static EffectManager _instance;

    private Dictionary<GameCharacter, List<ActiveStatusEffect>> _characterEffects;
    public static Action RefreshStatusEffect;
    private EffectManager()
    {
        _characterEffects = new Dictionary<GameCharacter, List<ActiveStatusEffect>>();
    }
    
    public static EffectManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new EffectManager();
            }
            return _instance;
        }
    }

    public void ApplyEffect(ActiveStatusEffect effect, List<GameCharacter> characters)
    {
        for (var i = 0; i < characters.Count; i++)
        {

            if (_characterEffects.ContainsKey(characters[i]))
            {
                List<ActiveStatusEffect> currentCharacterEffects = _characterEffects[characters[i]];
                bool alreadyHaveEffect = false;
                for (var i1 = 0; i1 < currentCharacterEffects.Count; i1++)
                {
                    if (currentCharacterEffects[i].statusEffect == effect.statusEffect)
                    {
                        alreadyHaveEffect = true;
                        currentCharacterEffects[i].statusCount+=effect.statusCount;
                    }
                }
                if (!alreadyHaveEffect)
                {
                    _characterEffects[characters[i]].Add(effect);
                }
            }
        }
        RefreshStatusEffect.Invoke();
    }
}

public class ActiveStatusEffect
{
    public StatusEffects statusEffect;
    public int statusCount;

    public ActiveStatusEffect(StatusEffects effect, int count)
    {
        
    }
}

public enum StatusEffects
{
    Artifact
}

public interface IStatusEffect
{
    void ApplyEffect(GameCharacter character);
    void RemoveEffect(GameCharacter character);
}