using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehaviour : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private bool _firing;
    [SerializeField] private Color _enabledColor;
    [SerializeField] private Color _disabledColor;
    private ItemBehaviour _itemBehaviour;
    
    private void Start()
    {
        _itemBehaviour = GetComponentInChildren<ItemBehaviour>();
        _animator.speed = 0;
        _animator.GetComponent<SpriteRenderer>().color = _disabledColor;
    }

    public List<Vector3> GetCurrentTargetsHighestPriority()
    {
        return _itemBehaviour.GetCurrentTargetsWithHighestPriority();
    }

    public void StartFiring()
    {
        _animator.gameObject.SetActive(true);
        _animator.GetComponent<SpriteRenderer>().color = _enabledColor;
        _firing = true;
        _animator.speed = 1;
    }

    public void StopFiring()
    {
        _firing = false;
        _animator.speed = 0;
    }

    private void Update()
    {
        if (_firing)
        {
            _animator.speed += Time.deltaTime;
        }
    }

    public void Hide()
    {
        _animator.gameObject.SetActive(false);
    }
}
