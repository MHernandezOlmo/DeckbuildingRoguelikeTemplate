using System.Collections.Generic;
using UnityEngine;

public class ScriptableObjectCharacterRepository : MonoBehaviour, ICharacterRepository
{
    
    [SerializeField] private List<SOCharacter> _characters;
    [SerializeField] private List<GameObject> _charactersPrefabs;
    

    public ICharacterData GetCharacterById(int id)
    {
        return _characters[id];
    }

    public IEnumerable<ICharacterData> GetAllCharacters()
    {
        return _characters;
    }    
    public IEnumerable<GameObject> GetAllCharacterPrefabs()
    {
        return _charactersPrefabs;
    }
}