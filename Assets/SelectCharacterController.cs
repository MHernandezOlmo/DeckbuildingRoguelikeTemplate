using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SelectCharacterController : MonoBehaviour
{
    [SerializeField] private List<UICharacterWidget> _widgets;
    [SerializeField] private ScriptableObjectCharacterRepository _characterRepository;
    private void Awake()
    {
        IServiceLocator serviceLocator = ServiceLocator.Instance;
        serviceLocator.Add<ICharacterRepository>(_characterRepository);
    }

    
    void Start()
    {
        //List<ICharacterData> characterDatas = ._characterRepository.GetAllCharacters().ToList();
        for (int i = 0; i < _widgets.Count; i++)
        {
            _widgets[i].ReceiveData(characterDatas[i]);
        }
    }
}