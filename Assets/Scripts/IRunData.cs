using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRunData
{
    string PickedCharacterID { get; }
    string Name { get; }
    string Description { get; }
    List<int> PickedRelicsID { get; }
}
