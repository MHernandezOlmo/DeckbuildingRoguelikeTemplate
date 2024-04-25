using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatusEffectUIWidget : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _textCounter;
    
    public void SetData(Sprite sprite, string text)
    {
        _image.sprite = sprite;
        _textCounter.text = text;
    }
    
}
