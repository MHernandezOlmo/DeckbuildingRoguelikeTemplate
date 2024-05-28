using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarWidget : MonoBehaviour
{
    [SerializeField] private Image _hpBar;

    private GameCharacter _character;

    public void SetGameCharacter(GameCharacter character)
    {
        _character = character;
        _character.OnHealthChanged += RefreshData;
        
    }
    public void RefreshData()
    {
        float fillAmount = (float)_character.CurrentHealth / (float)_character.MaxHealth;
        _hpBar.fillAmount = fillAmount;
    }
    public void RefreshData(float fillAmount)
    {
        _hpBar.fillAmount = fillAmount;
    }
}
