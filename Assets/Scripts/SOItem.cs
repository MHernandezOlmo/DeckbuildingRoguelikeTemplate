using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class SOItem : ScriptableObject, IItemData
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

    public virtual void ActivateEffect(GameObject player)
    {
        // Base implementation is empty
    }
}