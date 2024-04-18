using System;using System.Collections.Generic;
using UnityEngine.Serialization;

[System.Serializable]
public class RunData
{
    public int _selectedCharacterID;
    public List<int> _pickedRelicsID;
    public GameState _gameState;
    public int _currentMapNodeID;
    public int _currentBattleID;
    public int _seed;
    public RunData(int selectedCharacterID)
    {
        _selectedCharacterID = selectedCharacterID;
        _pickedRelicsID = new List<int>();
        _gameState = GameState.Map;
        _currentBattleID = -1;
        _currentMapNodeID = -1;
        string seedString = "myRandomSeed123";
        _seed =seedString.GetHashCode();;

    }
    public void AddPickedRelic(int relicID)
    {
        _pickedRelicsID.Add(relicID);
    }

    public void SetGameState(GameState newGameState)
    {
        _gameState = newGameState;
    }
}

public enum GameState
{
    Map, Battle
}