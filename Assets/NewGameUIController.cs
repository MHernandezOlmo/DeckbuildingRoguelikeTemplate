using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGameUIController : MonoBehaviour
{
    [SerializeField] private GameObject _newGameButton;
    [SerializeField] private GameObject _continueGameButton;
    void Start()
    {
        if (PersistenceManager.Instance.IsRunInProgress())
        {
            _newGameButton.gameObject.SetActive(false);
            _continueGameButton.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
