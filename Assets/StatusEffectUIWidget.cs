using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatusEffectUIWidget : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _textCounter;
    private ActiveStatusEffect _activeStatusEffect;

    public ActiveStatusEffect GetActiveStatusEffect()
    {
        return _activeStatusEffect;
    }
    
    public void SetData(ActiveStatusEffect myEffect)
    {
        _activeStatusEffect = myEffect;
        SOStatusEffect soStatusEffect = GameDataController.Instance.StatusEffectRepository.GetStatusEffectById((int)myEffect.statusEffect);
        _image.sprite =soStatusEffect.Icon;
        _textCounter.text = myEffect.statusCount.ToString();
    }
    
    
}
