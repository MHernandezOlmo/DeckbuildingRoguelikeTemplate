using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableObjectsRelicEffectsRepository : MonoBehaviour
{
    private Dictionary<int, RelicEffect> _relicEffects;
    
    public void InitalizeRelicEffects()
    {
        _relicEffects = new Dictionary<int, RelicEffect>();
        _relicEffects.Add(0,new Relic0());
        _relicEffects.Add(1,new Relic1());
        _relicEffects.Add(2,new Relic2());
        _relicEffects.Add(3,new Relic3());
        _relicEffects.Add(4,new Relic4());
        _relicEffects.Add(5,new Relic5());
        _relicEffects.Add(6,new Relic6());
    }
    public void ApplyRelicEffect(int relicID)
    {
        _relicEffects[relicID].ApplyEffect(HeroController.Instance.Character);
    }

}
