using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProgress : MonoBehaviour
{
    private static GameProgress _instance;
    public static GameProgress Instance {
        get {
            if (_instance == null) {
                _instance = new GameProgress();
            }
            return _instance;
        }
    }

    public void Save()
    {
        
    }
    
    

}
