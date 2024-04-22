using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    private List<int> _currentCombatInventory;
    private List<int> _hand;
    [SerializeField] private GameObject _inventoryHolder;
    [SerializeField] private GameObject _inventoryUIWidget;
    private WeaponBehaviour _currentWeapon;
    private bool _canFire;
    private bool _firing;
    void Start()
    {
        _currentCombatInventory = PersistenceManager.Instance.MyCurrentRun._pickedItemsID;
        _hand = _currentCombatInventory;
        ShuffleHand();
        _canFire = true;
        RefreshHandVisualization();
        CreateCurrentWeapon();
    }

    public void StartFiring()
    {
        if (_canFire)
        {
            _currentWeapon.StartFiring();
            _canFire = false;
            _firing = true;
        }
    }
    public void StopFiring()
    {
        if (_firing)
        {
            _currentWeapon.StopFiring();
            StartCoroutine(CrWaitAndStopFiring());
        }

        IEnumerator CrWaitAndStopFiring()
        {
            yield return new WaitForSeconds(2);
            _firing = false;
            _canFire = true;
            ReloadWeapon();
        }
    }

    public void ReloadWeapon()
    {
        Destroy(_currentWeapon.gameObject);
        _hand.RemoveAt(0);
        if (_hand.Count > 0)
        {
            CreateCurrentWeapon();   
        }
    }
    public void CreateCurrentWeapon()
    {
        int nextWeapon = _hand[0];
        print($"Mira, el arma {nextWeapon}");
        _currentWeapon = Instantiate(GameDataController.Instance.ItemRepository.GetItemPrefabByID(nextWeapon)).GetComponent<WeaponBehaviour>();
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
