using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class EnemiesBattleController : MonoBehaviour
{
    // Singleton instance
    private static EnemiesBattleController _instance;

    // Public property to access the singleton instance
    public static EnemiesBattleController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<EnemiesBattleController>();

                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(EnemiesBattleController).ToString());
                    _instance = singletonObject.AddComponent<EnemiesBattleController>();
                }
            }
            return _instance;
        }
    }

    // Prevents instantiation from other classes
    private EnemiesBattleController() {}

    // Ensure the instance is set in the Awake method
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }

    private List<BattleEnemy> _enemies;

    public IEnumerable<GameCharacter> GetEnemies()
    {
        List<GameCharacter> gameCharacters = new List<GameCharacter>();
        for (var i = 0; i < _enemies.Count; i++)
        {
            gameCharacters.Add(_enemies[i]._gameCharacter);
        }

        return gameCharacters;
    }

    public BattleEnemy GetSingleEnemy(int index)
    {
        return _enemies[index];
    }

    public List<BattleEnemy> GetBattleEnemies()
    {
        return _enemies;
    }

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

    public void RemoveEnemy(BattleEnemy enemy)
    {
        if (_enemies.Contains(enemy))
        {
            _enemies.RemoveAt(_enemies.IndexOf(enemy));
        }
    }

    public void DealDamageToAllEnemies(int damage)
    {
        for (var i = 0; i < _enemies.Count; i++)
        {
            //_enemies[i].ReceiveDamage(damage);
        }
    }

    public void InitializeEnemies()
    {
        IMapNode node = Map.Instance.GetNode(PersistenceManager.Instance.MyCurrentRun._currentBattleID);
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
