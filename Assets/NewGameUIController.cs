using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGameUIController : MonoBehaviour
{
    [SerializeField] private GameObject _newGameButton;
    [SerializeField] private GameObject _continueGameButton;
    [SerializeField] private GameObject _leaveGameButton;
    void Start()
    {
        if (PersistenceManager.Instance.IsRunInProgress())
        {
            _newGameButton.gameObject.SetActive(false);
            _continueGameButton.gameObject.SetActive(true);
            _leaveGameButton.gameObject.SetActive(true);
        }
    }

    void Update()
    {
        
    }
}
