using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPlayerVisualizer : MonoBehaviour
{
    [SerializeField] private MapVisualizer _mapVisualizer;   
    private void Awake()
    {
            
    }

    void Start()
    {
         int currentMapNodeID = PersistenceManager.Instance.MyCurrentRun._currentMapNodeID;
         Map currentMap = _mapVisualizer.GetMap();
         IMapNode currentMapNode = currentMap.GetNode(currentMapNodeID);
         for (var i = 0; i < currentMapNode.ConnectedNodes.Count; i++)
         {
             _mapVisualizer.GetMapNode(currentMap.GetCumulativeIndex(currentMapNode.ConnectedNodes[i])).EnableNode();
         }
         
         MapNode currentNode = _mapVisualizer.GetMapNode(currentMapNodeID);
         
         transform.position = currentNode.gameObject.transform.position;
    }

    
    void Update()
    {
        
    }
}
