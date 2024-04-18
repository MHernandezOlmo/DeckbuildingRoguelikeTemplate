using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableObjectEnemyRespository : MonoBehaviour
{
    [SerializeField]private List<SOEnemy> _enemies;
    [SerializeField] private List<GameObject> _enemyPrefabs;
    
    public SOEnemy GetEnemyById(int id)
    {
        return _enemies[id];
    }

    public IEnumerable<SOEnemy> GetAllEnemies()
    {
        return _enemies;
    }    
    public IEnumerable<GameObject> GetAllEnemyPrefabs()
    {
        return _enemyPrefabs;
    }
}
