using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ProgressData
{
    public int intData;
    public float floatData;
    public string stringData;
    
    public List<float> floatList;
    public List<int> intList;
    public List<string> stringList;
    

    public ProgressData(int newIntData, float newFloatData, string newStringData)
    {
        intData = newIntData;
        floatData = newFloatData;
        stringData = newStringData;

        floatList = new List<float>(){1f, 2f, 0.5f, 1.4f};
        intList = new List<int>(){1,2,3,5,3,1};
        stringList = new List<string>(){"Aasdf", "qwer", "poiu", "PINCHUI", "Cabra"};
        
    }
}
