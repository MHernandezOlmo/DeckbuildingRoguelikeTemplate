using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScriptableObjectItemRepository : MonoBehaviour, IItemRepository
{
    [SerializeField] private List<SOItem> _items;
    [SerializeField] private List<GameObject> _itemPrefabs;

    public IItemData GetItemById(int id)
    {
        return _items[id];
    }

    public IEnumerable<IItemData> GetAllItems()
    {
        return _items.ToList();
    }

    public GameObject GetItemPrefabByID(int id)
    {
        return _itemPrefabs[id];
    }
    
}