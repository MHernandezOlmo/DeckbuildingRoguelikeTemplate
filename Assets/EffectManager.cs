using System;using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class EffectManager
{
    private static EffectManager _instance;

    private Dictionary<GameCharacter, List<ActiveStatusEffect>> _characterEffects;

    public List<ActiveStatusEffect> GetMyEffects(GameCharacter character)
    {
        return _characterEffects[character];
    }
    public static Action RefreshStatusEffect;
    private EffectManager()
    {
        _characterEffects = new Dictionary<GameCharacter, List<ActiveStatusEffect>>();
    }
    private void LogCharacterEffects()
    {
        if (_characterEffects.Count == 0)
        {
            Debug.Log("No characters have any status effects currently.");
            return;
        }

        string logMessage = "All characters and their active status effects:\n";

        foreach (var characterEffectPair in _characterEffects)
        {
            GameCharacter character = characterEffectPair.Key;
            List<ActiveStatusEffect> effects = characterEffectPair.Value;

            // Start the log entry for this character
            logMessage += $"{character} has {effects.Count} active status effect(s):\n";

            // Add each active effect to the log entry
            foreach (var effect in effects)
            {
                logMessage += $"- {effect.statusEffect}, {effect.statusCount}\n";
            }
        }

        Debug.Log(logMessage);
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
            GameCharacter character = characters[i];
            if (_characterEffects.ContainsKey(character))
            {
                List<ActiveStatusEffect> currentCharacterEffects = _characterEffects[character];
                ActiveStatusEffect foundEffect = currentCharacterEffects.FirstOrDefault(e => e.statusEffect == effect.statusEffect);

                if (foundEffect != null)
                {
                    foundEffect.statusCount += effect.statusCount;
                }
                else
                {
                    _characterEffects[character].Add(new ActiveStatusEffect(effect.statusEffect, effect.statusCount));
                }
            }
            else
            {
                _characterEffects.Add(character, new List<ActiveStatusEffect> { new ActiveStatusEffect(effect.statusEffect, effect.statusCount) });
            }
        }
        LogCharacterEffects();
        RefreshStatusEffect.Invoke(); // Ensure this method is defined and correctly updates the game state
    }
}

public class ActiveStatusEffect
{
    public StatusEffects statusEffect;
    public int statusCount;

    public ActiveStatusEffect(StatusEffects effect, int count)
    {
        statusEffect = effect;
        statusCount = count;
    }
}

public enum StatusEffects
{
    Buff1, Buff2, Buff3
}

public interface IStatusEffect
{
    void ApplyEffect(GameCharacter character);
    void RemoveEffect(GameCharacter character);
}