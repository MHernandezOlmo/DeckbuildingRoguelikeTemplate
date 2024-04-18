using Newtonsoft.Json;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistenceManager
{
    private static PersistenceManager _instance;
    private IPersistenceService _persistenceService;

    public ProgressData MyProgressData { get; set; }
    public RunData _myCurrentRun;
    public RunData MyCurrentRun {
        get
        {
            if (_myCurrentRun == null)
            {
                LoadRunData();
            }
            return _myCurrentRun;
        }
        set
        {
            _myCurrentRun = value;
        }
    }

    public static PersistenceManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new PersistenceManager();
            }
            return _instance;
        }
    }

    public void StartRun(int characterID)
    {
        MyCurrentRun = new RunData(characterID);
        SaveRunData();
    }
    public bool IsRunInProgress()
    {
        return MyCurrentRun != null;
    }
    private PersistenceManager()
    {
        _persistenceService = new FilePersistenceService();
    }

    public void SaveRunData()
    {
        string jsonData = JsonConvert.SerializeObject(MyCurrentRun);
        _persistenceService.Save("RunData", jsonData);
    }
    public void SaveProgressData()
    {
        MyProgressData = new ProgressData();
        string jsonData = JsonConvert.SerializeObject(MyProgressData);
        _persistenceService.Save("ProgressData", jsonData);
    }
    public void AddPickedRelicToRun(int relicID)
    {
        if (MyCurrentRun != null)
        {
            MyCurrentRun.AddPickedRelic(relicID);
            SaveRunData();
        }
    }

    public void WinBattle()
    {
        MyCurrentRun._currentMapNodeID = MyCurrentRun._currentBattleID;
        SaveRunData();
        GameFlowEvents.LoadScene.Invoke("Map");
    }

    public void SelectBattle(int battleNode)
    {
        _myCurrentRun._currentBattleID =battleNode;
        SaveRunData();
    }
    public void LoadData()
    {
        _persistenceService.Load("ProgressData");
    }

    public void LoadRunData()
    {
        string runData = _persistenceService.Load("RunData");
        if (runData!= null)
        {
            MyCurrentRun  = JsonConvert.DeserializeObject<RunData>(runData);
        }
    }
    public void LoadAllData()
    {
        LoadData();
        LoadRunData();
    }

    public void EraseRun()
    {
        _persistenceService.Erase("RunData");
        MyCurrentRun = null;
        GameFlowEvents.LoadScene.Invoke("Menu");
    }

    public void SetGameState(GameState newGameState)
    {
        _myCurrentRun.SetGameState(newGameState);
        SaveRunData();
    }
}