using System;using System.Collections.Generic;
using UnityEditor;
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
    public int _maxHealth;
    public int _currentHealth;
    public List<int> _pickedItemsID;
    public int _gold;
    public RunData(int selectedCharacterID)
    {
        _selectedCharacterID = selectedCharacterID;
        switch (_selectedCharacterID)
        {
            case 0:
                _pickedItemsID = new List<int>(){1,2,3};
                break;
                
            case 1:
                _pickedItemsID = new List<int>(){0,1,2,3};
                break;
            
            case 2:
                _pickedItemsID = new List<int>(){4,3,2};
                break;
            
            case 3:
                _pickedItemsID = new List<int>(){1,1,1,1};
                break;
        }

        _maxHealth = 50;
        _currentHealth = 30;
        _pickedRelicsID = new List<int>();
        _gameState = GameState.Map;
        _currentBattleID = -1;
        _currentMapNodeID = -1;
        _gameState = GameState.Start;
        string seedString = "myRandomSeed123";
        _seed =seedString.GetHashCode();
        _gold = 0;
    }


    public void AddGold(int amount)
    {
        _gold += amount;
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
    Start, Map, Battle
}