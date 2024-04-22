using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetColliderPriority : MonoBehaviour
{
    [SerializeField] private int _colliderPriority;

    public int GetColliderPriority()
    {
        return _colliderPriority;
    } 
}
