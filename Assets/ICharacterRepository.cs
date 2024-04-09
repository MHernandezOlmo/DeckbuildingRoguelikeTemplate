using System.Collections.Generic;

public interface ICharacterRepository
{
    ICharacterData GetCharacterById(int id);
    IEnumerable<ICharacterData> GetAllCharacters();

}