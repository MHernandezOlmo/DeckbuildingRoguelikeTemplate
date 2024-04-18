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
        print("Nodo=> " +PersistenceManager.Instance.MyCurrentRun._currentBattleID);
        print("BattleRoom=> " +battleNode.GetBattleRoomID());
        
        List<SOEnemy> enemies = GameDataController.Instance.EnemyRespository.GetAllEnemies().ToList();
        List<GameObject> enemiesPrefab = GameDataController.Instance.EnemyRespository.GetAllEnemyPrefabs().ToList();
        GameObject character = Instantiate(enemiesPrefab[PersistenceManager.Instance.MyCurrentRun._selectedCharacterID], transform);
        character.transform.localPosition = Vector3.zero;
        character.transform.localRotation = Quaternion.identity;
    }
    
}
