using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSceneController : MonoBehaviour
{
    [SerializeField] private GameObject _playPanel;
    [SerializeField] private GameObject _compendiumPanel;
    [SerializeField] private GameObject _statisticsPanel;
    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private GameObject _characterSelectionPanel;
    [SerializeField] private GameObject _leaveGamePanel;
    private int _selectedCharacter;

    private void Awake()
    {
        PersistenceManager.Instance.LoadAllData();
    }

    public void Continue()
    {
        if (PersistenceManager.Instance.MyCurrentRun._gameState == GameState.Battle)
        {
            GameFlowEvents.LoadScene.Invoke("Battle");
        }
        else
        {
            GameFlowEvents.LoadScene.Invoke("Map");
        }
    }

    void Start()
    {
        
    }

    public void ShowPlayPanel()
    {
        _playPanel.gameObject.SetActive(true);
    }

    public void HidePlayPanel()
    {
        _playPanel.gameObject.SetActive(false);
    }

    public void ShowCompendiumPanel()
    {
        _compendiumPanel.gameObject.SetActive(true);
    }

    public void HideCompendiumPanel()
    {
        _compendiumPanel.gameObject.SetActive(false);
    }

    public void ShowStatisticsPanel()
    {
        _statisticsPanel.gameObject.SetActive(true);
    }

    public void HideStatisticsPanel()
    {
        _statisticsPanel.gameObject.SetActive(false);
    }

    public void ShowSettingsPanel()
    {
        _settingsPanel.gameObject.SetActive(true);
    }

    public void HideSettingsPanel()
    {
        _settingsPanel.gameObject.SetActive(false);
    }

    public void ShowCharacterSelectionPanel()
    {
        _playPanel.gameObject.SetActive(false);
        _characterSelectionPanel.gameObject.SetActive(true);
    }

    public void HideCharacterSelectionPanel()
    {
        _characterSelectionPanel.gameObject.SetActive(false);
        _playPanel.gameObject.SetActive(true);
    }

    public void SelectCharacter(int newCharacterID)
    {
        _selectedCharacter = newCharacterID;
    }

    public void LeaveGame()
    {
        _leaveGamePanel.gameObject.SetActive(true);
    }

    public void HideLeaveGamePanel()
    {
        _leaveGamePanel.gameObject.SetActive(false);
    }

    public void LeaveGameConfirmation()
    {
        PersistenceManager.Instance.EraseRun();
    }
    public void StartRun()
    {
        PersistenceManager.Instance.StartRun(_selectedCharacter);
        GameFlowEvents.LoadScene.Invoke("FirstRelicSelector");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    void Update()
    {
        
    }
}
