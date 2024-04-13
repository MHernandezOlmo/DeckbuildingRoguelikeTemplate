using UnityEngine;

public class PlayerPrefsPersistenceService : IPersistenceService
{
    public void Save(string key, string data)
    {
        PlayerPrefs.SetString(key, data);
        PlayerPrefs.Save();
    }

    public string Load(string key)
    {
        return PlayerPrefs.GetString(key);
    }
}