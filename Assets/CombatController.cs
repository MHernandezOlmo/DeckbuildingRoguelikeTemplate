using System;
using UnityEngine;
using UnityEngine.UI;

internal class CombatController : MonoBehaviour
{
    [SerializeField] private CombatAreaController _combatAreaController;
    [SerializeField] private InventoryController _inventoryController;
    [SerializeField] private Button _combatButton;
    
    private void OnEnable()
    {
        BattleController.OnCombatStart += InitializeCombat;
    }

    private void OnDisable()
    {
        BattleController.OnCombatStart -= InitializeCombat;
    }

    private void InitializeCombat()
    {
        _combatButton.gameObject.SetActive(true);
        _inventoryController.DrawItem();
        _combatAreaController.RefreshTargets();
    }
}