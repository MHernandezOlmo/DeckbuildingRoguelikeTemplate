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

    private void Start()
    {
        _targets = new List<GameObject>();
    }

    void RefreshTargets()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject newTarget = Instantiate(_targetPrefab, _targetHolder);
            bool positionFound = false;
            int attempts = 0;
            int maxAttempts = 100;
            while (!positionFound && attempts < maxAttempts)
            {
                float randomX = Random.Range(-2.9f, 2.9f); 
                float randomY = Random.Range(-1.9f, 1.9f);
                randomX = 0;
                randomY = 0;
                Vector2 newPosition = new Vector2(randomX, randomY);
                print(Physics2D.OverlapCircle(newPosition, 0.5f));
                if (Physics2D.OverlapCircle(newPosition, 0.5f) == null)
                {
                    newTarget.transform.localPosition = new Vector3(randomX, randomY, newTarget.transform.position.z);
                    positionFound = true;
                }
                attempts++;
            }

            _targets.Add(newTarget);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RefreshTargets();
        }
    }
}
