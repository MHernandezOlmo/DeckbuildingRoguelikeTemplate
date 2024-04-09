using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character")]

public class SOCharacter : ScriptableObject, ICharacterData
{

    [SerializeField] private string id;

    public string Id
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

}
