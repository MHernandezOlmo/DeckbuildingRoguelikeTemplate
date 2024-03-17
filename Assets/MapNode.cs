using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapNode : MonoBehaviour
{
    [SerializeField] private Sprite _battleSprite;
    [SerializeField] private Sprite _restSprite;
    [SerializeField] private Sprite _stageBossSprite;
    [SerializeField] private SpriteRenderer _renderer;
    void Start()
    {
        
    }

    public void SetBattleNode()
    {
        _renderer.sprite = _battleSprite;
    }

    public void SetRestNode()
    {
        _renderer.sprite = _restSprite;
    }

    public void SetStageBossNode()
    {
        _renderer.sprite = _stageBossSprite;
    }
    
}

