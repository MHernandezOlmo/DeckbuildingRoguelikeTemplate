using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ScriptableObjectRelicsRepository : MonoBehaviour, IRelicRepository
{
    
    [SerializeField] private List<SORelic> _relics;
    



    public IRelicData GetRelicById(int id)
    {
        return _relics[id];
    }



    
    public IEnumerable<IRelicData> GetAllRelics()
    {
        return _relics;
    }
    
    public IEnumerable<IRelicData> GetRandomUniqueRelics(int count)
    {
        List<IRelicData> randomRelics = new List<IRelicData>();

        if (count >= _relics.Count)
        {
            return _relics;
        }
        else
        {
            HashSet<int> selectedIndices = new HashSet<int>();
            while (selectedIndices.Count < count)
            {
                int randomIndex = Random.Range(0, _relics.Count);
                if (selectedIndices.Add(randomIndex))
                {
                    // Add successfully means this index wasn't already selected
                    randomRelics.Add(_relics[randomIndex]);
                }
            }
            return randomRelics;
        }
    }
}