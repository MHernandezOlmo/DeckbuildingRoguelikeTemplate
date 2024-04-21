
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItemRepository
{
    IItemData GetItemById(int id);
    IEnumerable<IItemData> GetAllItems();

}