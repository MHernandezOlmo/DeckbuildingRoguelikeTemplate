using System.Collections.Generic;

[System.Serializable]
public class RunData
{
    public int _selectedCharacterID;
    public List<int> _pickedRelicsID;
    public RunData(int selectedCharacterID)
    {
        _selectedCharacterID = selectedCharacterID;
        _pickedRelicsID = new List<int>();
    }
    public void AddPickedRelic(int relicID)
    {
        _pickedRelicsID.Add(relicID);
    }
}