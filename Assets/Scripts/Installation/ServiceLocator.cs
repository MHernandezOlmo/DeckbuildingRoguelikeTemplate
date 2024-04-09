using System;
using System.Collections.Generic;
using UnityEngine.Assertions;

public class ServiceLocator : IServiceLocator
{
    private static ServiceLocator _locator;
    public static ServiceLocator Instance=> _locator ??= new ServiceLocator();
    private readonly Dictionary<Type, object> _dictionary = new();

    public void Add<T>(T service)
    {
        var type = typeof(T);
        Assert.IsFalse(_dictionary.ContainsKey(type), "El Servicio Ya Existe");
        _dictionary.Add(type, service);
    }

    public T Get<T>()
    {
        var type = typeof(T);
        if (_dictionary.TryGetValue(type, out var service))
        {
            return (T)service;
        }
        else
        {
            throw new Exception($"Este servicio {type} no existe");
        }

    }

    public bool HasService<T>()
    {
        var type = typeof(T);
        return _dictionary.ContainsKey(type);
    }
}