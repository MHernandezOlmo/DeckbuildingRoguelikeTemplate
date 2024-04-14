using Newtonsoft.Json;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class PersistenceManager
{
    private static PersistenceManager _instance;
    private IPersistenceService _persistenceService;

    public ProgressData MyProgressData { get; set; }
    public RunData MyCurrentRun { get; set; }

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
}