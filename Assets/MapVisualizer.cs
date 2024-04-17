using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MapVisualizer : MonoBehaviour
{
    [SerializeField] private Sprite _battleSprite;
    [SerializeField] private Sprite _stageBossSpritee;
    [SerializeField] private Sprite _restSprite;

    [SerializeField] private GameObject _mapNodePrefab;
    private Map _currentMap;
    [SerializeField] private List<MapNode> _UIMapNodes;
    public Map GetMap()
    {
        return _currentMap;
    }

    private void OnEnable()
    {
        MapNode.OnNodePicked += PickNode;
    }

    private void OnDisable()
    {
        MapNode.OnNodePicked -= PickNode;
    }

    public MapNode GetMapNode(int mapNode)
    {
        return _UIMapNodes[mapNode];
    }
    void Start()
    {
        _currentMap = new Map();
        _UIMapNodes = new List<MapNode>();
        int nodeCount=0;
        for (int i = 0; i < _currentMap.Nodes.Count; i++)
        {
            for (int j = 0; j < _currentMap.Nodes[i].Count; j++)
            {
                MapNode node = Instantiate(_mapNodePrefab,
                        new Vector3(GetHorizontalPosition(j, _currentMap.Nodes[i].Count), -i, 0), quaternion.identity).GetComponent<MapNode>();
                switch (_currentMap.Nodes[i][j])
                {
                    case StageBossNode:
                        node.SetStageBossNode(nodeCount);
                        break;
                    
                    case RestNode:
                        node.SetRestNode(nodeCount);
                        break;
                    
                    case BattleNode:
                        node.SetBattleNode(nodeCount);
                        break;
                }

                nodeCount++;
                
                _UIMapNodes.Add(node);
            }
        }
    }


    public void PickNode(int node)
    {
        
        switch (_UIMapNodes[node]._type)
        {
            case MapNodes.Battle:
                PersistenceManager.Instance.SelectBattle(node);
                GameFlowEvents.LoadScene.Invoke("Battle");        
                break;
            
            case MapNodes.Boss:

                break;
            
            case MapNodes.Elite:
                
                break;
            
            case MapNodes.Rest:
                
                break;
        }
    }
    
    public float GetHorizontalPosition(int index, int amount)
    {
        float horizontalSeparation = 1f;
        float horizontalPosition = 0f;

        if (amount % 2 == 0)
        {
            // Even amount: Adjust so the middle point between two central elements is 0
            horizontalPosition = (index - (amount / 2f) + 0.5f) * horizontalSeparation;
        }
        else
        {
            // Odd amount: Adjust so the central element is at 0
            horizontalPosition = (index - (amount / 2)) * horizontalSeparation;
        }

        return horizontalPosition;
    }

}
