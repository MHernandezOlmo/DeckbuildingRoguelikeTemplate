using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableObjectStatusEffectRepository : MonoBehaviour
{
    [SerializeField] private List<SOStatusEffect> _statusEffects;
    [SerializeField] private List<GameObject> _statusEffectPrefabs;
    private Dictionary<StatusEffects, AlterStatusEffect> _statusEffectsEffects;


    public void Awake()
    {
        _statusEffectsEffects = new Dictionary<StatusEffects, AlterStatusEffect>();
        _statusEffectsEffects.Add(StatusEffects.Artifact, new DamageReducerAlterStatusEffect());
    }

    public void ApplyAlterStatusEffect(StatusEffects effect, GameCharacter character)
    {
        _statusEffectsEffects[effect].ApplyEffect(character);
    }

    public SOStatusEffect GetStatusEffectById(int id)
    {
        return _statusEffects[id];
    }

    public IEnumerable<SOStatusEffect> GetAllItems()
    {
        return _statusEffects;
    }

    public GameObject GetItemPrefabByID(int id)
    {
        return _statusEffectPrefabs[id];
    }
}

