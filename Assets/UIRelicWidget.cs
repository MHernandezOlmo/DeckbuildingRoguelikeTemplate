using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIRelicWidget : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private TextMeshProUGUI _title;
    [SerializeField] private TextMeshProUGUI _description;
    [SerializeField] private Image _image;
    private IRelicData _myRelicData;
    private NewRelicController _relicController;
    public void ReceiveData(IRelicData relicData, NewRelicController newRelicController)
    {
         _relicController = newRelicController;
        _myRelicData = relicData;
        _title.text = relicData.Name;
        _description.text = relicData.Description;
        _image.sprite = relicData.Icon;
    }
    
    public void PickRelic()
    {
        if (_myRelicData != null)
        {
            _relicController.PickRelic(_myRelicData.Id);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        PickRelic();
    }
}
