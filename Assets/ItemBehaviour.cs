using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{
    [SerializeField] private List<GameObject> _triggerGameObjects;

    private void Start()
    {
        _triggerGameObjects = new List<GameObject>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        _triggerGameObjects.Add(col.gameObject);
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        _triggerGameObjects.Remove(col.gameObject);
    }

}
