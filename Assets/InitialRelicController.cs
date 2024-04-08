using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

public class InitialRelicController : MonoBehaviour
{

    [SerializeField] private List<UIRelicWidget> _widgets;
    [SerializeField] private RelicManager _relicManager;
    void Start()
    {
        List<IRelicData> relicDatas = _relicManager._relicRepository.GetRandomUniqueRelics(3).ToList();
        for (int i = 0; i < _widgets.Count; i++)
        {
            _widgets[i].ReceiveData(relicDatas[i]);
        }
    }
}
