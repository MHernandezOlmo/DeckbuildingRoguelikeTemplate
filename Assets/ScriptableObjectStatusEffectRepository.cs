using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableObjectStatusEffectRepository : MonoBehaviour
{
    [SerializeField] private List<SOStatusEffect> _statusEffects;
    [SerializeField] private List<GameObject> _statusEffectPrefabs;

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

