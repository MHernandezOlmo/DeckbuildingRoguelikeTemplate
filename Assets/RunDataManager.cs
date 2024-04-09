using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class RunDataManager : IRunDataManager
{
    private IRunData _data;

    public IRunData LoadCurrentRun()
    {
        string jsonData = PlayerPrefs.GetString("CurrentRun");
        return JsonConvert.DeserializeObject<RunData>(jsonData);
    }

    public void SaveCurrentRun(IRunData currentRun)
    {
        RunData runData = new RunData("qewr","asdf","desc", new List<int>(){1,2,3,4,5,6} );
        string jsonData = JsonConvert.SerializeObject(runData, Formatting.Indented);
        PlayerPrefs.SetString("CurrentRun", jsonData);
    }
}
