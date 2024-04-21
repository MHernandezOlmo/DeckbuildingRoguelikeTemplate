using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    private List<int> _currentCombatInventory;
    private List<int> _hand;
    [SerializeField] private GameObject _inventoryHolder;
    [SerializeField] private GameObject _inventoryUIWidget;
    void Start()
    {
        _currentCombatInventory = PersistenceManager.Instance.MyCurrentRun._pickedItemsID;
        _hand = _currentCombatInventory;
        ShuffleHand();

        RefreshHandVisualization();
    }

    public void RefreshHandVisualization()
    {
        for (var i = 0; i < _hand.Count; i++)
        {
            Instantiate(_inventoryUIWidget, _inventoryHolder.transform).GetComponent<ItemUIRepresentation>().SetItem(GameDataController.Instance.ItemRepository.GetItemById(_hand[i]));
        }
    }
    
    private void ShuffleHand()
    {
        for (int i = 0; i < _hand.Count; i++)
        {
            int temp = _hand[i];
            int randomIndex = Random.Range(i, _hand.Count);
            _hand[i] = _hand[randomIndex];
            _hand[randomIndex] = temp;
        }
    }
    
    public void DrawItem()
    {
        if (_currentCombatInventory.Count > 0)
        {
            int itemIndex = _currentCombatInventory.Count - 1;
            _hand.Add(_currentCombatInventory[itemIndex]);
            _currentCombatInventory.RemoveAt(itemIndex);
        }
    }
    public int DeckSize()
    {
        return _currentCombatInventory.Count;
    }
    
}
