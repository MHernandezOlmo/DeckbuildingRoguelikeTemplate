using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharacterInstaller : MonoBehaviour
{
    private SelectCharacterController _selectCharacterController;
    
    private void Awake()
    {
        IServiceLocator serviceLocator = ServiceLocator.Instance;
    }

    public void Define(IServiceLocator serviceLocator)
    {
        CharacterManager _characterManagers;
        
    }

    public void Install(IServiceLocator serviceLocator)
    {
        
    }

    public void Initialize()
    {
        
    }
}
