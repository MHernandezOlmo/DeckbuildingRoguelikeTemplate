using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelicManager : MonoBehaviour
{ 
    [SerializeField] public ScriptableObjectRelicsRepository _relicRepository;

    private void Start()
    {
        foreach (var relic in _relicRepository.GetRandomUniqueRelics(3))
        {
            Debug.Log(relic);
        }
    }
}
