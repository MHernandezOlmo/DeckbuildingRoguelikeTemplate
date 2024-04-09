using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UICharacterWidget : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _title;
    [SerializeField] private TextMeshProUGUI _description;
    [SerializeField] private Image _image;

    public void ReceiveData(ICharacterData relicData)
    {
        _title.text = relicData.Name;
        _description.text = relicData.Description;
        _image.sprite = relicData.Icon;
    }
}
