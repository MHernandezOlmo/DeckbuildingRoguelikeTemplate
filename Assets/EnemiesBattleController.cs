using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemiesBattleController : MonoBehaviour
{
    
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
}
