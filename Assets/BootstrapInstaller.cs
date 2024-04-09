using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootstrapInstaller: MonoBehaviour
{
    private void Awake()
    {
        IServiceLocator serviceLocator = ServiceLocator.Instance;
    }
}
