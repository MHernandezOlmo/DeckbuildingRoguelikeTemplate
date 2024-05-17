using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class SOEnemy : ScriptableObject
{
    [SerializeField] private int id;

    public int Id
    {
        get
        {
            return id;
        }
    }

    [SerializeField] private string name;

    public string Name
    {
        get
        {
            return name;
        }
    }

    [SerializeField] private string description;

    public string Description
    {
        get
        {
            return description;
        }
    }

    [SerializeField] private Sprite icon;
    public Sprite Icon
    {
        get { return icon; }
    }

    [SerializeField] private int maxHP;

    public int MaxHP
    {
        get { return maxHP; }
    }
    public virtual void ActivateEffect(GameObject player)
    {
        
    }

    [SerializeField] public List<int> _actionList;
    
    
    
    
}
