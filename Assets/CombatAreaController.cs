using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CombatAreaController : MonoBehaviour
{
    [SerializeField] private GameObject _targetPrefab;
    [SerializeField] private Transform _targetHolder;

    private List<GameObject> _targets;
    private Vector3 center; 
    private void Start()
    {
        _targets = new List<GameObject>();
        RefreshTargets();
    }

    public void RefreshTargets()
    {
        for (var i = 0; i < _targets.Count; i++)
        {
            Destroy(_targets[i].gameObject);
        }
        _targets.Clear();

        for (int i = 0; i < 3; i++)
        {
            GameObject newTarget = Instantiate(_targetPrefab, _targetHolder);
            newTarget.name = $"Target {i}";
            
            bool positionFound = false;
            int attempts = 0;
            int maxAttempts = 100;
            while (!positionFound && attempts < maxAttempts)
            {
                float randomX = Random.Range(-2.9f, 2.9f); 
                float randomY = Random.Range(-1.9f, 1.9f);

                Vector2 newPosition = new Vector2(randomX + _targetHolder.position.x, randomY+_targetHolder.position.y);
                center = newPosition;
                if (Physics2D.OverlapCircle(newPosition, 0.5f) == null)
                {
                    newTarget.transform.localPosition = new Vector3(randomX, randomY, newTarget.transform.position.z);
                    positionFound = true;
                    Physics2D.SyncTransforms(); 
                }
                attempts++;

            }
            
            if (positionFound)
            {
                _targets.Add(newTarget);
            }
            else
            {
                Destroy(newTarget);
            }
        }
    }
}
