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

    public Map GetMap()
    {
        return _currentMap;
    }
    void Start()
    {
        _currentMap = new Map();

        for (int i = 0; i < _currentMap.Nodes.Count; i++)
        {
            for (int j = 0; j < _currentMap.Nodes[i].Count; j++)
            {
                MapNode node = Instantiate(_mapNodePrefab,
                        new Vector3(GetHorizontalPosition(j, _currentMap.Nodes[i].Count), -i, 0), quaternion.identity).GetComponent<MapNode>();
                switch (_currentMap.Nodes[i][j])
                {
                    case StageBossNode:
                        node.SetStageBossNode();
                        break;
                    
                    case RestNode:
                        node.SetRestNode();
                        break;
                    
                    case BattleNode:
                        node.SetBattleNode();
                        break;
                }
                
            }
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