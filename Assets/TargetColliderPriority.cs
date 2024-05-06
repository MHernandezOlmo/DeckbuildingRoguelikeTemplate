using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetColliderPriority : MonoBehaviour
{
    [SerializeField] private int _colliderPriority;
    [SerializeField] private TargetType _targetType;
    public int GetColliderPriority()
    {
        return _colliderPriority;
    } 
}

public enum TargetType
{
    Standard, Shield, Heal, Vampire
}