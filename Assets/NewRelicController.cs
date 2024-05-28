using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NewRelicController : MonoBehaviour
{
    public static NewRelicController Instance { get; private set; }
    [SerializeField] private List<UIRelicWidget> _widgets;
    [SerializeField] private GameObject _newRelicsCanvas;
    public void AddNewRelic()
    {
        
        List<IRelicData> relicDatas = GameDataController.Instance.RelicRepository.GetRandomUniqueRelics(3).ToList();
        for (int i = 0; i < _widgets.Count; i++)
        {
            _widgets[i].ReceiveData(relicDatas[i], this);
        }
        _newRelicsCanvas.SetActive(true);
    }
    void Start()
    {
        if (PersistenceManager.Instance.MyCurrentRun._pickedRelicsID.Count ==0)
        {
            AddNewRelic();
        }
    }

    public void PickRelic(int relicID)
    {
        PersistenceManager.Instance.AddPickedRelicToRun(relicID);
        _newRelicsCanvas.SetActive(false);
    }
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}