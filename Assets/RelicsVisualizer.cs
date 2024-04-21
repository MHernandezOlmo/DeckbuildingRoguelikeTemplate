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
