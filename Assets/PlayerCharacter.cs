using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public ScriptableObjectCharacterRepository _characterRepository;
    [SerializeField] private SpriteRenderer _renderer;
    private void Awake()
    { 
        List<ICharacterData> characters = _characterRepository.GetAllCharacters().ToList();
        List<GameObject> charactersPrefab = _characterRepository.GetAllCharacterPrefabs().ToList();
        ICharacterData myCharacter = characters[PersistenceManager.Instance.MyCurrentRun._selectedCharacterID];
        GameObject character = Instantiate(charactersPrefab[PersistenceManager.Instance.MyCurrentRun._selectedCharacterID], transform);
        character.transform.localPosition = Vector3.zero;
        character.transform.localRotation = Quaternion.identity;
        

    }
}
