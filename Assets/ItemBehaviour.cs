using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{
    private Dictionary<GameObject, List<CollisionData>> activeTargetCollisions = new Dictionary<GameObject, List<CollisionData>>();
    private class CollisionData
    {
        public int Priority;
        public Vector2 ContactPoint;
        public TargetColliderPriority TargetColliderPriority;

        public CollisionData(int priority, Vector2 contactPoint, TargetColliderPriority targetColliderPriority)
        {
            Priority = priority;
            ContactPoint = contactPoint;
            TargetColliderPriority = targetColliderPriority;
        }
    }

    private void Start()
    {
        activeTargetCollisions = new Dictionary<GameObject, List<CollisionData>>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        TargetColliderPriority tcp = col.gameObject.GetComponent<TargetColliderPriority>();
        GameObject parent = col.gameObject.transform.parent.gameObject;
        Vector2 contactPoint = col.contacts[0].point;

        if (!activeTargetCollisions.ContainsKey(parent))
        {
            activeTargetCollisions[parent] = new List<CollisionData>();
        }

        activeTargetCollisions[parent].Add(new CollisionData(tcp.GetColliderPriority(), contactPoint, tcp));
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        TargetColliderPriority tcp = col.gameObject.GetComponent<TargetColliderPriority>();
        GameObject parent = col.gameObject.transform.parent.gameObject;

        if (activeTargetCollisions.ContainsKey(parent))
        {
            var entryToRemove = activeTargetCollisions[parent].FirstOrDefault(d => d.Priority == tcp.GetColliderPriority());
            if (entryToRemove != null)
            {
                activeTargetCollisions[parent].Remove(entryToRemove);
                if (activeTargetCollisions[parent].Count == 0)
                {
                    activeTargetCollisions.Remove(parent);
                }
            }
        }
    }
    private void OnCollisionStay2D(Collision2D col)
    {
        AddOrUpdateCollision(col);
    }
    private void AddOrUpdateCollision(Collision2D col)
    {
        TargetColliderPriority tcp = col.gameObject.GetComponent<TargetColliderPriority>();
        GameObject parent = col.gameObject.transform.parent.gameObject;
        Vector2 contactPoint = col.contacts[0].point; // Gets the first contact point

        if (!activeTargetCollisions.ContainsKey(parent))
        {
            activeTargetCollisions[parent] = new List<CollisionData>();
        }

        // Check if there is already a collision entry with the same priority
        var existingCollision = activeTargetCollisions[parent]
            .FirstOrDefault(c => c.Priority == tcp.GetColliderPriority());

        if (existingCollision != null)
        {
            // Update the contact point of the existing collision
            existingCollision.ContactPoint = contactPoint;
        }
        else
        {
            // Add a new collision data entry
            activeTargetCollisions[parent].Add(new CollisionData(tcp.GetColliderPriority(), contactPoint, tcp));
        }
    }
    public List<HitTargetInfo> GetCurrentTargetsWithHighestPriority()
    {
        List<HitTargetInfo> hitPoints = new List<HitTargetInfo>();
        if (activeTargetCollisions.Count == 0)
        {
            Debug.Log("No current collisions.");
            return hitPoints;
        }

        string logMessage = "Current Collisions and Highest Priorities:\n";
        foreach (var targetEntry in activeTargetCollisions)
        {
            // Find the CollisionData with the highest priority
            var highestPriorityCollision = targetEntry.Value.OrderByDescending(c => c.Priority).First();

            logMessage += $"Target: {targetEntry.Key.name}, " +
                          $"Highest Priority: {highestPriorityCollision.Priority}, " +
                          $"Contact Point: {highestPriorityCollision.ContactPoint}\n";
            hitPoints.Add(new HitTargetInfo(highestPriorityCollision.ContactPoint, highestPriorityCollision.TargetColliderPriority));
        }
        return hitPoints;
    }
}

public struct HitTargetInfo
{
    public Vector3 _hitPoint;
    public TargetColliderPriority _targetColliderPriority;

    public HitTargetInfo(Vector3 hitPoint, TargetColliderPriority targetColliderPriority)
    {
        _hitPoint = hitPoint;
        _targetColliderPriority = targetColliderPriority;
    }
}