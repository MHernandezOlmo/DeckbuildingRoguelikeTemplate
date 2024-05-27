using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.WebCam;

public class BattleController : MonoBehaviour
{
    [SerializeField] private GameCharactersController _charactersController;
    [SerializeField] private InventoryController _inventoryController;
    [SerializeField] private CombatController _combatController;

    public static Action OnCombatStart;

    
    public void EndCombat()
    {
        StartCoroutine(CrEndCombat());

        IEnumerator CrEndCombat()
        {
            yield return new WaitForSeconds(1);
        }
    }

    public void WinBattle()
    {
        PersistenceManager.Instance.WinBattle();
        GameFlowEvents.LoadScene.Invoke("Map");
    }

    private IEnumerator Start()
    {
        Initialize();
        
        yield return null;
        yield return null;
        ScriptableObjectsRelicEffectsRepository _relicEffectsRepository = new ScriptableObjectsRelicEffectsRepository();
        _relicEffectsRepository.InitalizeRelicEffects();
        foreach (var relic in PersistenceManager.Instance._myCurrentRun._pickedRelicsID)
        {
            _relicEffectsRepository.ApplyRelicEffect(relic);
        }

        
        yield return new WaitForSeconds(1);
        StartCombat();
    }

    public void Initialize()
    {
        _charactersController.InitializeCharacters();
        _inventoryController.InitializeInventory();
        
    }

    public void StartCombat()
    {
        OnCombatStart.Invoke();   
    }
    
    

    public void LoseBattle()
    {
    }
    
}