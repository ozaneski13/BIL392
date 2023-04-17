using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeButtonPressed : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu = null;
    [SerializeField] private GameObject _gameSceneUI = null;

    public void ResumeButtonPressedFunction()
    {
        _pauseMenu.SetActive(false);
        _gameSceneUI.SetActive(true);
        Time.timeScale = 1f;
    }
}
