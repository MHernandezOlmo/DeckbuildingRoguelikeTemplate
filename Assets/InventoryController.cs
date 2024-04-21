using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    private List<int> _currentCombatInventory;
    private List<int> _hand;
    void Start()
    {
        _currentCombatInventory = PersistenceManager.Instance.MyCurrentRun._pickedItemsID;
        _hand = new List<int>();

        ShuffleDeck();

    }

    private void ShuffleDeck()
    {
        for (int i = 0; i < _currentCombatInventory.Count; i++)
        {
            int temp = _currentCombatInventory[i];
            int randomIndex = Random.Range(i, _currentCombatInventory.Count);
            _currentCombatInventory[i] = _currentCombatInventory[randomIndex];
            _currentCombatInventory[randomIndex] = temp;
        }
    }
    
    public void DrawItem()
    {
        if (_currentCombatInventory.Count > 0)
        {
            int itemIndex = _currentCombatInventory.Count - 1; // Get the last item index
            _hand.Add(_currentCombatInventory[itemIndex]); // Add it to the hand
            _currentCombatInventory.RemoveAt(itemIndex); // Remove it from the deck
        }
    }
    public int DeckSize()
    {
        return _currentCombatInventory.Count;
    }
    
}
