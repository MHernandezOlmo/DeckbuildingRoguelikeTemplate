using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualFeedback : MonoBehaviour
{
    public List<GameCharacter> _gameCharacters;
    private void OnEnable()
    {
        GameCharacter.OnCharacterCreate += AddCharacter;
    }

    public void AddCharacter(GameCharacter newCharacter)
    {
        if (_gameCharacters == null)
        {
            _gameCharacters = new List<GameCharacter>();
        }
        _gameCharacters.Add(newCharacter);
        Debug.Log("added");
        newCharacter.OnPostDamageReceived += ShowDamage;
    }

    public void ShowDamage(GameCharacter character, int damage)
    {
        GameObject targetCharacter =GameCharactersController.Instance.GetObjectFromGameCharacter(character);
        Debug.Log("DAMAGE RECEIVED QWER QWER"+targetCharacter.name);
    }
    
}
