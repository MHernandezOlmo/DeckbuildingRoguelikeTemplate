using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HeroController : MonoBehaviour
{
    private static HeroController _instance;
    public Action OnAttack;
    public static HeroController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<HeroController>();
                if (_instance == null)
                {
                    GameObject singleton = new GameObject(typeof(HeroController).ToString());
                    _instance = singleton.AddComponent<HeroController>();
                }
            }
            return _instance;
        }
    }

    private GameCharacter _character;
    private ICharacterData _characterData;
    private GameObject _characterInstance;

    private int _baseDamage = 20;
    private int _combatDamage = 0;

    public int HitDamage { get; set; }
    public float FinalDamageMultiplier { get; set; }

    public GameCharacter Character
    {
        get => _character;
        set
        {
            _character = value;
        }
    }

    
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print($"Current-> {Character.CurrentHealth} / Max -> {Character.MaxHealth}");
        }
    }

    public void InitializeHero()
    {
        List<ICharacterData> characters = GameDataController.Instance.CharacterRepository.GetAllCharacters().ToList();
        List<GameObject> charactersPrefab = GameDataController.Instance.CharacterRepository.GetAllCharacterPrefabs().ToList();
        _characterData = characters[PersistenceManager.Instance.MyCurrentRun._selectedCharacterID];
        _characterInstance = Instantiate(charactersPrefab[PersistenceManager.Instance.MyCurrentRun._selectedCharacterID], transform);
        _character = new GameCharacter(PersistenceManager.Instance.MyCurrentRun._maxHealth);
        _characterInstance.GetComponentInChildren<HealthBarWidget>().SetGameCharacter(_character);
        _character.CurrentHealth = PersistenceManager.Instance.MyCurrentRun._currentHealth;
        _characterInstance.GetComponentInChildren<CharacterStatusEffectUIManager>().SetCharacter(_character);
        _characterInstance.transform.localPosition = Vector3.zero;
        _characterInstance.transform.localRotation = Quaternion.identity;
        GameCharactersController.Instance.AddCharacter(_character,_characterInstance);

    }

    public void DealDamage(GameCharacter target)
    {
        FinalDamageMultiplier = 1f;
        OnAttack?.Invoke();
        StartCoroutine(CrDealDamage());

        IEnumerator CrDealDamage()
        {
            Character.OnPreDamage?.Invoke();
            yield return null;
            int finalDamage = _baseDamage + _combatDamage + HitDamage;
            finalDamage =Mathf.FloorToInt(FinalDamageMultiplier*finalDamage);
            Debug.Log($"Base:{_baseDamage}, Combat{_combatDamage}. Hit{HitDamage}");
            target.ReceiveDamage(finalDamage);
        }
    }
}
