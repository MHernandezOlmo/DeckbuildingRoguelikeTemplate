using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatusEffectUIManager : MonoBehaviour
{
    [SerializeField] private GameObject _statusEffectUIWidget;
    [SerializeField] private GameCharacter _character;
    private List<StatusEffectUIWidget> _effectUIWidgets;

    private void Start()
    {
        _effectUIWidgets = new List<StatusEffectUIWidget>();
    }

    private void OnEnable()
    {
        EffectManager.RefreshStatusEffect += RefreshData;
    }

    private void OnDisable()
    {
        EffectManager.RefreshStatusEffect -= RefreshData;
    }

    public void RefreshData()
    {
        List<ActiveStatusEffect> myActiveEffects = EffectManager.Instance.GetMyEffects(_character);
        for (var j = _effectUIWidgets.Count-1; j >=0; j--)
        {
            bool effectFound = false;
            for (var i = 0; i < myActiveEffects.Count; i++)
            {
                if (myActiveEffects[i].statusEffect == _effectUIWidgets[j].GetActiveStatusEffect().statusEffect)
                {
                    effectFound = true;
                }
            }

            if (!effectFound)
            {
                Destroy(_effectUIWidgets[j].gameObject);
                _effectUIWidgets.RemoveAt(j);
            }
        }
        

        for (var i = 0; i < myActiveEffects.Count; i++)
        {
            bool hasEffectAlready = false;
            for (var j = 0; j < _effectUIWidgets.Count; j++)
            {
                if (_effectUIWidgets[j].GetActiveStatusEffect().statusEffect == myActiveEffects[i].statusEffect)
                {
                    _effectUIWidgets[j].SetData(myActiveEffects[i]);
                    hasEffectAlready = true;
                }
            }

            if (!hasEffectAlready)
            {
                StatusEffectUIWidget newEffect = Instantiate(_statusEffectUIWidget, transform).GetComponent<StatusEffectUIWidget>();
                newEffect.SetData(myActiveEffects[i]);
                _effectUIWidgets.Add(newEffect);
            }
        }
    }
}