using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRunDataManager
{
    IRunData LoadCurrentRun();
    void SaveCurrentRun(IRunData currentRun);
}
