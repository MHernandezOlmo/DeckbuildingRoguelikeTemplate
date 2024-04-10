using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCharacterController : MonoBehaviour
{

    [SerializeField] private ScriptableObjectCharacterRepository _characterRepository;
    [SerializeField] private List<UICharacterWidget> _widgets;
    void Start()
    {
        for (int i = 0; i < _widgets.Count; i++)
        {
            _widgets[i].ReceiveData(_characterRepository.GetCharacterById(i));
        }
    }
    
}
