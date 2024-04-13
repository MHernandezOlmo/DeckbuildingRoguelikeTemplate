using Newtonsoft.Json;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class PersistenceManager
{
    private static PersistenceManager _instance;
    private IPersistenceService _persistenceService;

    public ProgressData MyProgressData { get; set; }

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

    // Private constructor ensures only the singleton class can instantiate this.
    private PersistenceManager()
    {
        _persistenceService = new FilePersistenceService();
    }

    // Example method
    public void SaveData()
    {
        MyProgressData = new ProgressData(5, 0.1234f,"Pruebita");
        string jsonData = JsonConvert.SerializeObject(MyProgressData);
        _persistenceService.Save("ProgressData", jsonData);
    }
    
    public void LoadData(string key)
    {
        Debug.Log(_persistenceService.Load(key));
    }
}