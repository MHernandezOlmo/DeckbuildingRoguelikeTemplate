using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.WebCam;

public class BattleController : MonoBehaviour
{
    public void WinBattle()
    {
        PersistenceManager.Instance.WinBattle();    
    }

    private void Start()
    {
        PersistenceManager.Instance.SetGameState(GameState.Battle);
    }

    public void LoseBattle()
    {
    }
    
}
