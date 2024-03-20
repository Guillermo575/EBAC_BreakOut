using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class GameManager : MonoBehaviour
{
    public bool IsPause = false;
    public bool LevelCleared = false;
    public bool GameEnd = false;
    public event EventHandler OnGameStart;
    public event EventHandler OnGamePause;
    public event EventHandler OnGameResume;
    public event EventHandler OnGameEnd;
    public event EventHandler OnGameOver;
    public event EventHandler OnGameExit;
    public event EventHandler OnGameLevelCleared;
    public event EventHandler OnLifeLose;

    private void Awake()
    {
        OnGameStart += delegate { Time.timeScale = 1; };
        OnGamePause += delegate { Time.timeScale = 0; };
        OnGameResume += delegate { Time.timeScale = 1; };
        OnGameEnd += delegate { Time.timeScale = 0; };
        OnGameOver += delegate { Time.timeScale = 0; };
        OnGameExit += delegate { Time.timeScale = 1; };
        OnGameLevelCleared += delegate { Time.timeScale = 0; };
    }
    private void Start()
    {
        StartGame();
    }
    public void StartGame()
    {
        GameEnd = false;
        OnGameStart?.Invoke(this, EventArgs.Empty);
    }
    public void PauseGame()
    {
        IsPause = true;
        OnGamePause?.Invoke(this, EventArgs.Empty);
    }
    public void ResumeGame()
    {
        IsPause = false;
        OnGameResume?.Invoke(this, EventArgs.Empty);
    }
    public void ExitGame()
    {
        OnGameExit?.Invoke(this, EventArgs.Empty);
    }
    public void LevelClearedGame()
    {
        GameEnd = true;
        LevelCleared = true;
        OnGameLevelCleared?.Invoke(this, EventArgs.Empty);
    }
    public void GameOver()
    {
        GameEnd = true;
        OnGameOver?.Invoke(this, EventArgs.Empty);
    }
    public void LifeLose()
    {
        OnLifeLose?.Invoke(this, EventArgs.Empty);
    }
}