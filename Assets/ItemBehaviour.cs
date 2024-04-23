using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ItemBehaviour : MonoBehaviour
{

    private Dictionary<GameObject, List<int>> activeTargetCollisions = new Dictionary<GameObject, List<int>>();
    private void Start()
    {
        activeTargetCollisions = new Dictionary<GameObject, List<int>>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        TargetColliderPriority tcp = col.GetComponent<TargetColliderPriority>();
        

        GameObject parent =col.gameObject.transform.parent.gameObject;
        if (!activeTargetCollisions.ContainsKey(parent))
        {
            activeTargetCollisions[parent] = new List<int>();
        }
        activeTargetCollisions[parent].Add(tcp.GetColliderPriority());

    }

    
    private void OnTriggerExit2D(Collider2D col)
    {
        TargetColliderPriority tcp = col.GetComponent<TargetColliderPriority>();
        GameObject parent = col.gameObject.transform.parent.gameObject;
        if (activeTargetCollisions.ContainsKey(parent))
        {
            activeTargetCollisions[parent].Remove(tcp.GetColliderPriority());
            if (activeTargetCollisions[parent].Count == 0)
            {
                activeTargetCollisions.Remove(parent);
            }
        }
    }
    
    public Dictionary<GameObject, int> GetCurrentTargetsHighestPriority()
    {
        Dictionary<GameObject, int> highestPriorities = new Dictionary<GameObject, int>();
        foreach (var targetEntry in activeTargetCollisions)
        {
            int highestPriority = targetEntry.Value.Max(); 
            highestPriorities[targetEntry.Key] = highestPriority;
        }
        return highestPriorities;
    }
    
    public void LogCurrentCollisions()
    {
        var targetsAndPriorities = GetCurrentTargetsHighestPriority();
        if (targetsAndPriorities.Count == 0)
        {
            Debug.Log("No current collisions.");
            return;
        }

        string logMessage = "Current Collisions and Highest Priorities:\n";
        foreach (KeyValuePair<GameObject, int> entry in targetsAndPriorities)
        {
            logMessage += $"Target: {entry.Key.name}, Highest Priority: {entry.Value}\n";
        }
        Debug.Log(logMessage);
    }
}