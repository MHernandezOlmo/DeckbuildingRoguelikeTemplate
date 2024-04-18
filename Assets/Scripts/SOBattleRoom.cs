using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New BattleRoom", menuName = "BattleRoom")]
public class SOBattleRoom : ScriptableObject
{
    [SerializeField] private List<SOEnemy> _enemies;
    public List<SOEnemy> Enemies
    {
        get => _enemies;
        set => _enemies = value;
    }
}
