using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

internal class CombatController : MonoBehaviour
{
    [SerializeField] private CombatAreaController _combatAreaController;
    [SerializeField] private InventoryController _inventoryController;
    [SerializeField] private Button _combatButton;

    public void EndPlayerTurn()
    {
        StartCoroutine(CrStartEnemyTurn());
        
        IEnumerator CrStartEnemyTurn()
        {
            yield return new WaitForSeconds(2);
            
        }
    }
    public void ReceiveDamageData(List<HitTargetInfo> info)
    {
        foreach (var hitTargetInfo in info)
        {
            print($"Aplico el efecto de haberle dado a la diana {hitTargetInfo._targetColliderPriority.GetTargetType()}, con prioridad {hitTargetInfo._targetColliderPriority.GetColliderPriority()}");
        }
        FindObjectOfType<BattleController>().EndCombat();
    }
    
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