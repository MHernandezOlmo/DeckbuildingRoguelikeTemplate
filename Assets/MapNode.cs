using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MapNode : MonoBehaviour
{
    [SerializeField] private Sprite _battleSprite;
    [SerializeField] private Sprite _restSprite;
    [SerializeField] private Sprite _stageBossSprite;
    [SerializeField] private SpriteRenderer _renderer;
    private int _nodeID;
    private bool _enabled;

    public static Action<int> OnNodePicked;
    [FormerlySerializedAs("type")] public MapNodes _type; 
    public void OnMouseDown()
    {
        if (_enabled)
        {
            OnNodePicked.Invoke(_nodeID);
        }
    }

    public void EnableNode()
    {
        _enabled = true;
        _renderer.color = Color.magenta;
    }

    public void SetBattleNode(int ID)
    {
        _nodeID = ID;
        _type = MapNodes.Battle;
        _renderer.sprite = _battleSprite;
    }

    public void SetRestNode(int ID)
    {
        _nodeID = ID;
        _type = MapNodes.Rest;
        _renderer.sprite = _restSprite;
    }

    public void SetStageBossNode(int ID)
    {
        _nodeID = ID;
        _type = MapNodes.Boss;
        _renderer.sprite = _stageBossSprite;
    }
}

public enum MapNodes
{
        Battle, Rest, Elite, Boss
}

