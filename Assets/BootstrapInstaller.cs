using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootstrapInstaller: MonoBehaviour
{
    [SerializeField] private ScriptableObjectCharacterRepository _scriptableObjectCharacterRepository;
    private void Awake()
    {
        IServiceLocator serviceLocator = ServiceLocator.Instance;
        //_scriptableObjectCharacterRepository.Define(this);
    }
}
