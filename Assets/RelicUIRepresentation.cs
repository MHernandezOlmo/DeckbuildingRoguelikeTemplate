using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RelicUIRepresentation : MonoBehaviour
{
    [SerializeField] private Image _image;

    public void SetRelic(IRelicData getRelicById)
    {
        _image.sprite = getRelicById.Icon;
    }
}
