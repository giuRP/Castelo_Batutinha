using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public event Action OnPickUpAllKeys;

    public event Action OnPauseGame;
    public event Action OnResumeGame;

    private bool isPaused = false;
    private int pickedKeys = 0;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void GamePauseControll()
    {
        if (Time.timeScale == 0 && !isPaused)
            return;

        isPaused = !isPaused;

        if (isPaused)
        {
            Pause();
        }
        else
        {
            Resume();
        }
    }

    private void Pause()
    {
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Locked;
        OnPauseGame?.Invoke();
    }

    private void Resume()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        OnResumeGame?.Invoke();
    }

    public void CheckWinCondition()
    {
        pickedKeys++;

        if(pickedKeys >= 3)
            OnPickUpAllKeys?.Invoke();
    }
}
