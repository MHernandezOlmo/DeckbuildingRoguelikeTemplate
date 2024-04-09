using System.Collections.Generic;
using UnityEngine;

public class ScriptableObjectCharacterRepository : MonoBehaviour, ICharacterRepository
{
    
    [SerializeField] private List<SOCharacter> _characters;
    

    public ICharacterData GetCharacterById(int id)
    {
        return _characters[id];
    }

    public IEnumerable<ICharacterData> GetAllCharacters()
    {
        return _characters;
    }
}