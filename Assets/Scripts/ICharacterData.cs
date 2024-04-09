using UnityEngine;

public interface ICharacterData
{
    string Id { get; }
    string Name { get; }
    string Description { get; }
    Sprite Icon { get; }
}