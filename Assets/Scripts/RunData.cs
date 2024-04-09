using System.Collections.Generic;

[System.Serializable]
public class RunData : IRunData
{
    public string PickedCharacterID { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public List<int> PickedRelicsID { get; private set; }

    // Constructor to initialize a new run data instance
    public RunData(string pickedCharacterID, string name, string description, List<int> pickedRelicsID)
    {
        PickedCharacterID = pickedCharacterID;
        Name = name;
        Description = description;
        PickedRelicsID = new List<int>(pickedRelicsID);
    }
}