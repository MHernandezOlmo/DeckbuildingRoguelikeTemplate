using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MapVisualizer : MonoBehaviour
{
    [SerializeField] private Sprite _battleSprite;
    [SerializeField] private Sprite _stageBossSpritee;
    [SerializeField] private Sprite _restSprite;

    [SerializeField] private GameObject _mapNodePrefab; 
    void Start()
    {
        Map map = new Map();

        for (int i = 0; i < map.Nodes.Count; i++)
        {
            for (int j = 0; j < map.Nodes[i].Count; j++)
            {
                Instantiate(_mapNodePrefab, new Vector3(GetHorizontalPosition(j,map.Nodes[i].Count),-i/2f,0), quaternion.identity);
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
