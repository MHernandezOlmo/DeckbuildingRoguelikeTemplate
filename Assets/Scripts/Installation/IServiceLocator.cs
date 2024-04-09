using System.Collections;
using UnityEngine;

public interface IServiceLocator
{
    void Add<T>(T service);

    T Get<T>();

    bool HasService<T>();
}