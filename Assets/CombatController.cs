using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

internal class CombatController : MonoBehaviour
{
    [SerializeField] private CombatAreaController _combatAreaController;
    [SerializeField] private BattleController _battleController;
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
            var enemies = FindObjectOfType<EnemiesBattleController>().GetBattleEnemies();
            if (enemies.Count > 0)
            {
                foreach (var enemy in enemies)
                {
                    int nextAction = enemy.GetNextAction();
                    yield return new WaitForSeconds(2);
                    print("Soy enemigo" + enemy.name + " y hago la acción: " + nextAction);
                }
            
                yield return new WaitForSeconds(2);
                EndEnemiesTurn();    
            }
            else
            {
                _battleController.WinBattle();
            }
            
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
    
    public void ReceiveTargetsHitData(List<HitTargetInfo> info)
    {
        
        foreach (var hitTargetInfo in info)
        {
            print($"Aplico el efecto de haberle dado a la diana {hitTargetInfo._targetColliderPriority.GetTargetType()}, con prioridad {hitTargetInfo._targetColliderPriority.GetColliderPriority()}");
        }

        
        BattleEnemy enemy = FindObjectOfType<EnemiesBattleController>().GetSingleEnemy(0);
        IGameCharacter enemyGameCharacter = enemy._gameCharacter;
        FindObjectOfType<GameCharactersController>().CurrentHeroController.DealDamage(enemyGameCharacter, 60);
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

    public void DealDamage(IGameCharacter damageDealer, IGameCharacter target, int damage)
    {
        
    }
    public enum CombatAction
    {
        DealDamage, Heal, EarnArmour, ApplyStatusEffect 
    }
}