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

        StartCoroutine(CrEndPlayerTurn());
        
        IEnumerator CrEndPlayerTurn()
        {
            
            yield return new WaitForSeconds(2);
            _combatButton.gameObject.SetActive(false);
            _inventoryController.ClearCombatArea();
            print("Termina turno jugador");
            yield return new WaitForSeconds(1);
            print("Comienza Turno Enemigo");
        
            StartCoroutine(CrStartEnemyTurn());
        }
        

        
        
        IEnumerator CrStartEnemyTurn()
        {
            yield return new WaitForSeconds(2);
            print("Empieza el turno del enemigo");
            foreach (var enemy in FindObjectOfType<EnemiesBattleController>().GetBattleEnemies())
            {
                int nextAction = enemy.GetNextAction();
                yield return new WaitForSeconds(2);
                print("Soy enemigo" + enemy.name + " y hago la acción: " + nextAction);
            }
            yield return new WaitForSeconds(2);
            EndEnemiesTurn();
        }
        
    }

    public void EndEnemiesTurn()
    {
        print("Termino turno de los enemigos.");
        StartCoroutine(CrWaitAndStartPlayerTurn());

        IEnumerator CrWaitAndStartPlayerTurn()
        {
            yield return new WaitForSeconds(3);
            print("Termina Turno");

            StartPlayerTurn();
        }
    }
    
    public void ReceiveDamageData(List<HitTargetInfo> info)
    {
        foreach (var hitTargetInfo in info)
        {
            print($"Aplico el efecto de haberle dado a la diana {hitTargetInfo._targetColliderPriority.GetTargetType()}, con prioridad {hitTargetInfo._targetColliderPriority.GetColliderPriority()}");
        }
        EndPlayerTurn();
        //FindObjectOfType<BattleController>().EndCombat();
    }
    
    private void OnEnable()
    {
        BattleController.OnCombatStart += InitializeCombat;
    }

    private void OnDisable()
    {
        BattleController.OnCombatStart -= InitializeCombat;
    }

    public void StartPlayerTurn()
    {
        print("Comienza el turno del jugador");
        _combatButton.gameObject.SetActive(true);
        _inventoryController.DrawItem();
        _combatAreaController.RefreshTargets();
    }
    private void InitializeCombat()
    {
        StartPlayerTurn();
    }
}