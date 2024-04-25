using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatusEffectUIManager : MonoBehaviour
{
    [SerializeField] private GameObject _statusEffectUIWidget;
    [SerializeField] private GameCharacter _character;
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
        //Continuar por aqui   
    }
}
