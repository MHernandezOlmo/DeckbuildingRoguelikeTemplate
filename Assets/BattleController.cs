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
    public void WinBattle()
    {
            
    }

    private IEnumerator Start()
    {
        Initialize();
        yield return new WaitForSeconds(2);
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