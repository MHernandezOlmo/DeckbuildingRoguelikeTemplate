using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class RelicsVisualizer : MonoBehaviour
{
    [SerializeField] private GameObject _relicHolder;
    [SerializeField] private GameObject _relicUIRepresentation;
    
    void Start()
    {
        RefreshRelics();
    }

    private void OnEnable()
    {
        PersistenceManager.OnPickRelic += RefreshRelics;
    }

    private void OnDisable()
    {
        PersistenceManager.OnPickRelic -= RefreshRelics;
    }

    void RefreshRelics()
    {
        for (var i = 0; i < PersistenceManager.Instance.MyCurrentRun._pickedRelicsID.Count; i++)
        {
            RelicUIRepresentation singleRelic =Instantiate(_relicUIRepresentation, _relicHolder.transform).GetComponent<RelicUIRepresentation>();
            singleRelic.SetRelic(GameDataController.Instance.RelicRepository.GetRelicById(PersistenceManager.Instance.MyCurrentRun._pickedRelicsID[i]));
        }
    }
    void Update()
    {
        
    }
}
