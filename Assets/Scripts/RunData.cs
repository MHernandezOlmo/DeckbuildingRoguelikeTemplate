using System.Collections.Generic;

[System.Serializable]
public class RunData
{
    public int _selectedCharacterID;
    public RunData(int selectedCharacterID)
    {
        _selectedCharacterID = selectedCharacterID;
    }
}