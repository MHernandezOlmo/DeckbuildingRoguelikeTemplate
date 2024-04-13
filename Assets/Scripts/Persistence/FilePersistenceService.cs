using System.IO;
using UnityEngine;

public class FilePersistenceService : IPersistenceService
{
    private string folderPath;
    public FilePersistenceService()
    {
        folderPath = Path.Combine(Application.persistentDataPath, "SaveData");
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }
    }
    public void Save(string key, string data)
    {
        string filePath = Path.Combine(folderPath, key + ".json");
        File.WriteAllText(filePath, data);
    }

    public string Load(string key)
    {
        string filePath = Path.Combine(folderPath, key + ".json");
        if (File.Exists(filePath))
        {
            return File.ReadAllText(filePath);
        }

        return "{}";
    }
}