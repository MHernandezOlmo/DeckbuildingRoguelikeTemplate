using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class EnemiesBattleController : MonoBehaviour
{
    private List<BattleEnemy> _enemies;

    private void OnEnable()
    {
        BattleEnemy.OnEnemyCreated += AddNewEnemy;
        BattleEnemy.OnEnemyDied += RemoveEnemy;
    }

    
    private void OnDisable()
    {
        BattleEnemy.OnEnemyCreated -= AddNewEnemy;
        BattleEnemy.OnEnemyDied -= RemoveEnemy;
    }

    private void AddNewEnemy(BattleEnemy enemy)
    {
        if (_enemies == null)
        {
            _enemies = new List<BattleEnemy>();
        }
        _enemies.Add(enemy);
    }

    private void RemoveEnemy(BattleEnemy enemy)
    {
        if (_enemies.Contains(enemy))
        {
            //_enemies.RemoveAt(_enemies.IndexOf(enemy));
        }
    }

    public void DealDamageToAllEnemies(int damage)
    {
        for (var i = 0; i < _enemies.Count; i++)
        {
            _enemies[i].ReceiveDamage(10);
        }
    }
    
    void Start()
    {
        IMapNode node =  Map.Instance.GetNode(PersistenceManager.Instance.MyCurrentRun._currentBattleID);
        BattleNode battleNode = node as BattleNode;

        List<SOEnemy> enemies = GameDataController.Instance.EnemyRespository.GetAllEnemies().ToList();
        List<GameObject> enemiesPrefab = GameDataController.Instance.EnemyRespository.GetAllEnemyPrefabs().ToList();
        
        SOBattleRoom battleRoom = GameDataController.Instance.BattleRoomRepository.GetBattleRoomById(battleNode.GetBattleRoomID());
        for (var i = 0; i < battleRoom.Enemies.Count; i++)
        {
            GameObject enemy = Instantiate(enemiesPrefab[battleRoom.Enemies[i].Id], transform.GetChild(i));
            enemy.transform.localPosition = Vector3.zero;
            enemy.transform.localRotation = Quaternion.identity;
        }
    }

    private void Update()
    {
        
    }
}


