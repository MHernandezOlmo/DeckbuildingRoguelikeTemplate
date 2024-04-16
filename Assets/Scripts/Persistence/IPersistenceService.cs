using System.Collections;
using System.Collections.Generic;

public interface IPersistenceService
{
    void Save(string key, string data);
    string Load(string key);
    void Erase(string key);
}