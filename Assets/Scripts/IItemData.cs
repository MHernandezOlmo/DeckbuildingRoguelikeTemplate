using UnityEngine;

public interface IItemData
{
    int Id { get; }
    string Name { get; }
    string Description { get; }
    Sprite Icon { get; }
}