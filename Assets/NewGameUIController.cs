using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGameUIController : MonoBehaviour
{
    [SerializeField] private GameObject _newGameButton;
    [SerializeField] private GameObject _continueGameButton;
    void Start()
    {
        if (PersistenceManager.Instance.MyProgressData.intData ==0)
        {
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
