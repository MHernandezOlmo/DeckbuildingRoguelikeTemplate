using UnityEngine;

public interface IRelicData
{
    int Id { get; }
    string Name { get; }
    string Description { get; }
    Sprite Icon { get; }
}