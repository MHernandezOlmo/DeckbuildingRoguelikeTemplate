using System;
using System.Collections.Generic;
using UnityEngine;

public class GameCharactersController : MonoBehaviour
{
    [SerializeField] private EnemiesBattleController _enemiesBattleController;
    private Dictionary<GameCharacter, GameObject> _gameCharactersObjects;

    // Singleton instance
    private static GameCharactersController _instance;

    // Public property to access the singleton instance
    public static GameCharactersController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameCharactersController>();
                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(GameCharactersController).ToString());
                    _instance = singletonObject.AddComponent<GameCharactersController>();
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        // Ensure that there's only one instance of GameCharactersController
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject); // Optional: to persist the instance across scenes
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }

        _gameCharactersObjects = new Dictionary<GameCharacter, GameObject>();
    }
    public void AddCharacter(GameCharacter character, GameObject characterGameObject)
    {
        _gameCharactersObjects.Add(character, characterGameObject);
    }

    public GameObject GetObjectFromGameCharacter(GameCharacter character)
    {
        return _gameCharactersObjects[character];
    }
    

    private void Start()
    {
        // Initialization logic can remain here if needed
    }

    public void InitializeCharacters()
    {
        HeroController.Instance.InitializeHero();
        _enemiesBattleController.InitializeEnemies();
    }
}