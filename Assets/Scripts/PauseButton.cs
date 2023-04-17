using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu = null;
    [SerializeField] private GameObject _gameSceneUI = null;

    public void PauseButtonPressed()
    {
        _pauseMenu.SetActive(true);
        _gameSceneUI.SetActive(false);
        Time.timeScale = 0.1f;
    }
}