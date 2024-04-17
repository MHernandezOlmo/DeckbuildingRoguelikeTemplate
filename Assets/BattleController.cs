using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    public void WinBattle()
    {
        PersistenceManager.Instance.WinBattle();    
    }

    public void LoseBattle()
    {
    }
    
}
