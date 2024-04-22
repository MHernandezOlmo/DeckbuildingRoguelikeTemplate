using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{
    [SerializeField] private List<GameObject> _triggerGameObjects;
    [SerializeField] private List<int> _priorities;
    private void Start()
    {
        _triggerGameObjects = new List<GameObject>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        GameObject parent =col.gameObject.transform.parent.gameObject;

        if (_triggerGameObjects.Contains(parent))
        {
            int newPriority = col.GetComponent<TargetColliderPriority>().GetColliderPriority();
            int indexOfParent = _triggerGameObjects.IndexOf(parent);
            if (newPriority > _priorities[indexOfParent])
            {
                _priorities[indexOfParent] = newPriority;
            }
        }
        else
        {
            _triggerGameObjects.Add(parent);
            _priorities.Add(col.GetComponent<TargetColliderPriority>().GetColliderPriority());
        }
    }

    
    private void OnTriggerExit2D(Collider2D col)
    {
        _triggerGameObjects.Remove(col.gameObject);
    }
}