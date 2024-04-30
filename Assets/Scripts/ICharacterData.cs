using UnityEngine;

public interface ICharacterData
{
    string Id { get; }
    int BaseDamage { get; }
    string Name { get; }
    string Description { get; }
    Sprite Icon { get; }
}