using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUIRepresentation : MonoBehaviour
{
    [SerializeField] private Image _image;

    public void SetItem(IItemData item)
    {
        _image.sprite = item.Icon;
    }
}
