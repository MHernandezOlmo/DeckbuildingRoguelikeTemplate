using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RunStateController : MonoBehaviour
{
    [SerializeField] private NewRelicController _newRelicController;
    private static RunStateController _instance;
    public static RunStateController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<RunStateController>();

                if (_instance == null)
                {
                    GameObject singleton = new GameObject(typeof(RunStateController).ToString());
                    _instance = singleton.AddComponent<RunStateController>();
                    DontDestroyOnLoad(singleton);
                }
            }

            return _instance;
        }
    }

    private string currentScene;

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

    public void RelicAndMap()
    {
        LoadMapState();   
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(1);
        print(PersistenceManager.Instance.MyCurrentRun._gameState);
        switch (PersistenceManager.Instance.MyCurrentRun._gameState)
        {
            case GameState.Start:
                _newRelicController.OnRelicPicked += RelicAndMap;
                _newRelicController.AddNewRelic();
                break;
            
            case GameState.Battle:
                LoadBattle();
                break;
            case GameState.Map:
                LoadMapState();
                break;
        }
    }

    public void LoadMapState()
    {
        currentScene = "Map";
        PersistenceManager.Instance._myCurrentRun._gameState = GameState.Map;
        PersistenceManager.Instance.SaveRunData();
        GameFlowEvents.LoadSceneAditive.Invoke("Map");
    }

    public void LoadBattle()
    {
        if (currentScene != null)
        {
            print(currentScene);
            SceneManager.UnloadSceneAsync(currentScene);
        }
        Camera.main.transform.position = new Vector3(0, 0, -10);
        PersistenceManager.Instance._myCurrentRun._gameState = GameState.Battle;
        PersistenceManager.Instance.SaveRunData();
        GameFlowEvents.LoadSceneAditive.Invoke("Battle");

    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            LoadMapState();
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            LoadBattle();
        }
    }
    
    
}