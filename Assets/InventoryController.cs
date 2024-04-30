using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    [SerializeField] private GameObject bulletPrefab;
    private List<GameObject> _targets;

    void Start()
    {
        _targets = new List<GameObject>();
        _currentCombatInventory = PersistenceManager.Instance.MyCurrentRun._pickedItemsID;
        _hand = new List<int>( _currentCombatInventory);
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
            int damageToDeal = 0;
            foreach (var hitPoint in _currentWeapon.GetCurrentTargetsHighestPriority())
            {
                yield return new WaitForSeconds(0.2f);
                _targets.Add(Instantiate(bulletPrefab,hitPoint, Quaternion.identity));
                damageToDeal += 2;
            }
            yield return new WaitForSeconds(2);

            List<IGameCharacter> enemies = FindObjectOfType<EnemiesBattleController>().GetEnemies().ToList(); 
            print($"Mira -> {damageToDeal}" );
            FindObjectOfType<HeroController>().DealDamage(enemies[Random.Range(0,enemies.Count)], damageToDeal);
            _firing = false;
            _canFire = true;
            ReloadWeapon();
        }
    }

    public void ReloadWeapon()
    {
        ClearTargets();
        FindObjectOfType<CombatAreaController>().RefreshTargets();
        Destroy(_currentWeapon.gameObject);
        _hand.RemoveAt(0);
        RefreshHandVisualization();
        if (_hand.Count > 0)
        {
            CreateCurrentWeapon();   
        }
    }

    private void ClearTargets()
    {
        for (var i = 0; i < _targets.Count; i++)
        {
            Destroy(_targets[i].gameObject);
        }
        _targets.Clear();
    }

    public void CreateCurrentWeapon()
    {
        int nextWeapon = _hand[0];
        _currentWeapon = Instantiate(GameDataController.Instance.ItemRepository.GetItemPrefabByID(nextWeapon)).GetComponent<WeaponBehaviour>();
    }
    
    void DestroyAllChildren(GameObject parent)
    {
        foreach (Transform child in parent.transform)
        {
            Destroy(child.gameObject);
        }
    }
    public void RefreshHandVisualization()
    {
        DestroyAllChildren(_inventoryHolder);   
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
