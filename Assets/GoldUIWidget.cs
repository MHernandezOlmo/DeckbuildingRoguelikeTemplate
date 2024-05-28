using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GoldUIWidget : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _goldText;
    void Start()
    {
        RefreshGold();
    }

    private void OnEnable()
    {
        PersistenceManager.OnGoldChange += RefreshGold;
    }

    private void OnDisable()
    {
        PersistenceManager.OnGoldChange -= RefreshGold;
    }

    public void RefreshGold()
    {
        _goldText.text = PersistenceManager.Instance.MyCurrentRun._gold.ToString();
    }
}
