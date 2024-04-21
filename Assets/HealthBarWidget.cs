using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarWidget : MonoBehaviour
{
    [SerializeField] private Image _hpBar;

    public void RefreshData(float fillAmount)
    {
        _hpBar.fillAmount = fillAmount;
    }
}
