using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HeroController : MonoBehaviour
{
    private IGameCharacter _character;
    private IDamageDealer _currentDamageDealer;
    private ICharacterData _characterData;
    private GameObject _characterInstance;
    public static Action<DamageBoostDecorator> AddNewDamageBoostDecorator;

    private void OnEnable()
    {
        AddNewDamageBoostDecorator += AddDamageDecorator;
    }
    

    private void Start()
    {
        List<ICharacterData> characters =GameDataController.Instance.CharacterRepository.GetAllCharacters().ToList();
        List<GameObject> charactersPrefab = GameDataController.Instance.CharacterRepository.GetAllCharacterPrefabs().ToList();
        _characterData= characters[PersistenceManager.Instance.MyCurrentRun._selectedCharacterID];
        _characterInstance = Instantiate(charactersPrefab[PersistenceManager.Instance.MyCurrentRun._selectedCharacterID], transform);
        _character = new IGameCharacter();
        _currentDamageDealer = _character;
        _characterInstance.transform.localPosition = Vector3.zero;
        _characterInstance.transform.localRotation = Quaternion.identity;
    }
    public void DealDamage(IGameCharacter target, int damage)
    {
        if (_currentDamageDealer != null)
        {
            int baseDamage = damage;
            _currentDamageDealer.DealDamage(target, baseDamage);
        }
    }

    public void AddDamageDecorator(DamageBoostDecorator damageBoostDecorator)
    {
        damageBoostDecorator.SetDamageDealerToBeWrapped(_currentDamageDealer);
        _currentDamageDealer = damageBoostDecorator;
    }
}
