using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    
    [SerializeField] private SpriteRenderer _renderer;
    private void Awake()
    { 
        List<ICharacterData> characters =GameDataController.Instance.CharacterRepository.GetAllCharacters().ToList();
        List<GameObject> charactersPrefab = GameDataController.Instance.CharacterRepository.GetAllCharacterPrefabs().ToList();
        ICharacterData myCharacter = characters[PersistenceManager.Instance.MyCurrentRun._selectedCharacterID];
        GameObject character = Instantiate(charactersPrefab[PersistenceManager.Instance.MyCurrentRun._selectedCharacterID], transform);
        character.transform.localPosition = Vector3.zero;
        character.transform.localRotation = Quaternion.identity;
    }
}
