using UnityEngine;

public interface IRelicData
{
    string Id { get; }
    string Name { get; }
    string Description { get; }
    Sprite Icon { get; }
    void ActivateEffect(GameObject player);
}