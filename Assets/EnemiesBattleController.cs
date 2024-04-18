using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemiesBattleController : MonoBehaviour
{
    private ScriptableObjectEnemyRespository _enemyRespository;
    void Start()
    {
        List<SOEnemy> enemies = _enemyRespository.GetAllEnemies().ToList();
        List<GameObject> enemiesPrefab = _enemyRespository.GetAllEnemyPrefabs().ToList();
        GameObject character = Instantiate(enemiesPrefab[PersistenceManager.Instance.MyCurrentRun._selectedCharacterID], transform);
        character.transform.localPosition = Vector3.zero;
        character.transform.localRotation = Quaternion.identity;
    }
    
}
