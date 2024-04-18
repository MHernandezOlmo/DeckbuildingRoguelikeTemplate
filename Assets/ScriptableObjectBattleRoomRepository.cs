using System.Collections.Generic;
using UnityEngine;

public class ScriptableObjectBattleRoomRepository : MonoBehaviour
{
    
    [SerializeField] private List<SOBattleRoom> _battleRooms;
    

    public SOBattleRoom GetBattleRoomById(int id)
    {
        return _battleRooms[id];
    }

    public IEnumerable<SOBattleRoom> GetAllBattleRooms()
    {
        return _battleRooms;
    }    
}